using DynamicDialogCore.Models.DTO;
using DynamicDialogBot.Services;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Internals.Fibers;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DynamicDialogBot.Dialogs
{
    [Serializable]
    public class DynamicDialogDialog : IDialog<object>
    {
        private readonly IResponseService _responseService;
        private string _language = "sv";
        private static Random _random = new Random();

        public DynamicDialogDialog(IResponseService responseService)
        {
            //set the language based on the users chat app preferences
            SetLanguageBasedOnThread();
            //register the response service
            SetField.NotNull(out _responseService, nameof(responseService), responseService);
        }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }
        /// <summary>
        /// act on the users message
        /// if a user clicked on a button, the reponse will look like action:[next_response_id]:[side_effect#side_effect#...]
        /// if a user just writes text it will normally not start by action:
        /// the very first action (triggered from the message controller) is action:0:
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result">message comming in from the user</param>
        /// <returns></returns>
        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var message = (await result).Text;

            Debug.WriteLine($"DBG: you said {message}");

            if (message.StartsWith("action:"))
                await RespondToSelectedAction(context, message);
            else
                await SendDefaultResponse(context);

            context.Wait(MessageReceivedAsync);
        }

        /// <summary>
        /// respond to the selected action
        /// </summary>
        /// <param name="context"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        private async Task RespondToSelectedAction(IDialogContext context, string action)
        {
            try
            {
                (string nextResponseId, List<string> sideEffects) = ParseAction(action);

                //default start action
                if (nextResponseId == "0")
                {
                    await SendStartResponse(context);
                }
                else
                {
                    if (sideEffects.Any())
                        await ActOnSideEffects(sideEffects);

                    await SendTypingMessageAsync(context);
                    await SendResponse(context, (await _responseService.GetResponseAsync(nextResponseId, _language)));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DBG: something went wrong {action}");
                await SendTypingMessageAsync(context);
                await SendResponse(context, (await _responseService.GetConfigAsync(_language)).ErrorResponse);
            }
        }
        /// <summary>
        /// act on action side effects - for now we only have one side effect (toggle language)
        /// </summary>
        /// <param name="sideEffects"></param>
        /// <returns></returns>
        private async Task ActOnSideEffects(List<string> sideEffects)
        {
            if (sideEffects[0] == "Toggle Language")
            {
                if (_language == "en")
                    _language = "sv";
                else
                    _language = "en";

                await _responseService.GetConfigAsync(_language);
            }
        }
        /// <summary>
        /// Parse the action to get the nextResponseId and sideEffects if any
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <summary>
        /// sets the language based on the users selected language in the chat app
        /// </summary>
        private void SetLanguageBasedOnThread()
        {
            var preferredLanguage = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            if (preferredLanguage == "en")
                _language = "en";
        }

        #region Parsing response
        private (string nextResponseId, List<string> sideEffects) ParseAction(string action)
        {
            string nextResponseId = "0";
            List<string> sideEffects = new List<string>();

            var actionParts = action.Split(':');
            if (actionParts.Count() >= 3 && !string.IsNullOrEmpty(actionParts[2]))
                sideEffects = ParseSideEffects(actionParts[2]);
            if (actionParts.Count() >= 2)
                nextResponseId = actionParts[1];

            return (nextResponseId, sideEffects);
        }
        /// <summary>
        /// parse the side effects string into individual side effects
        /// </summary>
        /// <param name="sideEffectsStr"></param>
        /// <returns></returns>
        private List<string> ParseSideEffects(string sideEffectsStr)
        {
            List<string> sideEffects = new List<string>();
            var parts = sideEffectsStr.Split('#');

            foreach (var part in parts)
            {
                if (!string.IsNullOrEmpty(part))
                    sideEffects.Add(part);
            }
            return sideEffects;
        }
        #endregion

        #region Standard Responses
        /// <summary>
        /// send a standard message - stating we didnt understand - if the user has not clicked on an action 
        /// (we don't support free text yet)
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task SendDefaultResponse(IDialogContext context)
        {
            await SendTypingMessageAsync(context);

            var config = await _responseService.GetConfigAsync(_language);
            var defaultResponse = config.DefaultResponse;
            await SendResponse(context, defaultResponse);
        }
        /// <summary>
        /// send the start response - this is a standard response from the bot to get the conversation started
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private async Task SendStartResponse(IDialogContext context)
        {
            await SendTypingMessageAsync(context);

            var config = await _responseService.GetConfigAsync(_language);
            var startResponse = await _responseService.GetResponseAsync(config.StartAction.NextResponseId, _language);
            await SendResponse(context, startResponse);
        }
        #endregion

        #region Sending the response
        /// <summary>
        /// respond to the user (using prompts and cards)
        /// </summary>
        /// <param name="context"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task SendResponse(IDialogContext context, Response response)
        {
            //if we didn't get a proper response to display, display the error response
            if (response == null)
                response = (await _responseService.GetConfigAsync(_language)).ErrorResponse;

            if (response == null)
                return;

            //send the response prompts and responses
            await SendResponse(context, response, actionsAsCarousel: true);
        }
        /// <summary>
        /// send each prompt individually
        /// </summary>
        /// <param name="context"></param>
        /// <param name="response"></param>
        /// <param name="actionsAsCarousel">if true - actions are sent as individual cards, grouped in a carouse, if false - actions are sent as buttons on a single hero card</param>
        /// <returns></returns>
        private async Task SendResponse(IDialogContext context, Response response, bool actionsAsCarousel)
        {
            //display all prompts individually
            foreach (var prompt in response.Texts)
            {
                await SendTypingMessageAsync(context, true);
                await context.PostAsync(prompt);
            }
            //if response contains a link/video or image - display it as a separate card
            if (response.MediaType != "none")
                await SendMedia(context, response);

            //send actions as a grouped card or carousel
            if (actionsAsCarousel)
                await SendActionsAsCarousel(context, response);
            else
                await SendActionsAsGroupedCard(context, response);
        }
        #endregion  

        #region Sending actions
        /// <summary>
        /// all actions are sent as individual cards - grouped in a carousel
        /// </summary>
        /// <param name="context"></param>
        /// <param name="response"></param>
        /// <param name="cardTitle"></param>
        /// <returns></returns>
        private async Task SendActionsAsCarousel(IDialogContext context, Response response, string cardTitle = "")
        {
            await SendTypingMessageAsync(context, true);
            var message = context.MakeMessage();

            message.Text = cardTitle;
            message.Attachments = new List<Attachment>();
            message.AttachmentLayout = AttachmentLayoutTypes.Carousel;

            foreach (var action in response.Actions)
            {
                message.Attachments.Add(CreateActionCard(action));
            }
            if (response.IncludeDefaultAction)
            {
                message.Attachments.Add(CreateActionCard((await _responseService.GetConfigAsync(_language)).DefaultAction));
            }

            await context.PostAsync(message);
        }
        /// <summary>
        /// all actions grouped on one single card, each action is a button
        /// </summary>
        /// <param name="context"></param>
        /// <param name="response"></param>
        /// <param name="cardTitle"></param>
        /// <returns></returns>
        private async Task SendActionsAsGroupedCard(IDialogContext context, Response response, string cardTitle = "")
        {
            await SendTypingMessageAsync(context);
            var message = context.MakeMessage();

            if (!string.IsNullOrEmpty(cardTitle))
                message.Text = cardTitle;

            var actions = new List<CardAction>();
            foreach (var action in response.Actions)
                actions.Add(CreateCardAction(action));

            if (response.IncludeDefaultAction)
                actions.Add(CreateCardAction((await _responseService.GetConfigAsync(_language)).DefaultAction));

            message.Attachments.Add(new HeroCard() { Buttons = actions }.ToAttachment());
            await context.PostAsync(message);
        }
        /// <summary>
        /// create individual cards for carousel
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private Attachment CreateActionCard(DynamicDialogCore.Models.DTO.Action action)
        {
            var card = new HeroCard
            {
                Text = action.Text,
                Buttons = new List<CardAction>(){
                    new CardAction()
                    {
                        Title = $"{action.ShortActionText}",
                        Type = ActionTypes.PostBack,
                        Value = $"action:{action.NextResponseId}:{action.GetSideEffectsAsString()}",
                    }
                }
            };
            return card.ToAttachment();
        }
        /// <summary>
        /// create action button for grouped actions
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        private CardAction CreateCardAction(DynamicDialogCore.Models.DTO.Action action)
        {
            return new CardAction()
            {
                Title = $"{action.Text}",
                Type = ActionTypes.PostBack,
                Value = $"action:{action.NextResponseId}:{action.GetSideEffectsAsString()}",
            };
        }
        #endregion

        #region Special cards for MediaType = link / video / image
        /// <summary>
        /// generate cards for links / video or image responses
        /// </summary>
        /// <param name="context"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        private async Task SendMedia(IDialogContext context, Response response)
        {
            Attachment card = null;
            switch (response.MediaType)
            {
                case "none":
                    break;
                case "link":
                    card = GetLinkCard(response);
                    break;
                case "video":
                    card = GetVideoCard(response);
                    break;
                case "image":
                    card = GetImageCard(response);
                    break;
            }
            if (card != null)
                await ShowCard(context, card);
        }
        /// <summary>
        /// show attachment card
        /// </summary>
        /// <param name="context"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        private async Task ShowCard(IDialogContext context, Attachment card)
        {
            var message = context.MakeMessage();
            message.Attachments = new List<Attachment>();
            message.Attachments.Add(card);
            await context.PostAsync(message);
        }
        /// <summary>
        /// create image type card
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private Attachment GetImageCard(Response response)
        {
            try
            {
                var image = response.Image;
                Attachment attachment = new Attachment();

                if (image.IsAnimated)
                {
                    var imageCard = new AnimationCard();
                    if (!string.IsNullOrEmpty(image.Url))
                    {
                        imageCard.Media = new List<MediaUrl> { new MediaUrl(image.Url) };
                    }
                    attachment = imageCard.ToAttachment();
                }
                else
                {
                    var imageCard = new ThumbnailCard();
                    if (!string.IsNullOrEmpty(image.Url))
                    {
                        imageCard.Images = new List<CardImage> { new CardImage(image.Url) };
                    }
                    attachment = imageCard.ToAttachment();
                }
                return attachment;
            }
            catch (Exception ex) { return null; }
        }
        /// <summary>
        /// create video type card
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private Attachment GetVideoCard(Response response)
        {
            try
            {
                var video = response.Video;

                var videoCard = new VideoCard();

                if (!string.IsNullOrEmpty(video.Title))
                    videoCard.Title = video.Title;

                videoCard.Media = new List<MediaUrl>
                {
                    new MediaUrl(){Url = video.Url}
                };

                return videoCard.ToAttachment();
            }
            catch (Exception ex) { return null; }
        }
        /// <summary>
        /// create link type card
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private Attachment GetLinkCard(Response response)
        {
            try
            {
                var link = response.Link;

                var linkCard = new ThumbnailCard();
                if (!string.IsNullOrEmpty(link.Title))
                    linkCard.Title = link.Title;

                var cleanUrl = new Uri(link.Url).GetLeftPart(UriPartial.Path);
                linkCard.Buttons = new List<CardAction> { new CardAction(ActionTypes.OpenUrl, cleanUrl, value: link.Url) };
                if (!string.IsNullOrEmpty(link.Thumbnail))
                {
                    linkCard.Images = new List<CardImage> { new CardImage(link.Thumbnail) };
                }

                return linkCard.ToAttachment();
            }
            catch (Exception ex) { return null; }
        }
        #endregion  

        /// <summary>
        /// send ... message to indicate typing
        /// </summary>
        /// <param name="context"></param>
        /// <param name="addDelay"></param>
        /// <returns></returns>
        private static async Task SendTypingMessageAsync(IDialogContext context, bool addDelay = false)
        {
            //create the typing message
            var typing = context.MakeMessage();
            typing.Type = ActivityTypes.Typing;

            //send the message
            await context.PostAsync(typing);

            //simulate delay if requested
            if (addDelay)
                await Task.Delay((int)(_random.NextDouble() * 1000));
        }
    }
}