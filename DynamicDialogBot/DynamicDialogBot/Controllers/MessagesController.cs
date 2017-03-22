using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Collections.Generic;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Autofac;
using Microsoft.Bot.Builder.Internals.Fibers;

namespace DynamicDialogBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private readonly ILifetimeScope _scope;
        private static Dictionary<string, int> _conversations = new Dictionary<string, int>();

        public MessagesController(ILifetimeScope scope)
        {
            SetField.NotNull(out _scope, nameof(scope), scope);
        }

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                using (var scope = DialogModule.BeginLifetimeScope(_scope, activity))
                {
                    await Conversation.SendAsync(activity, () => scope.Resolve<IDialog<object>>());
                }
            }
            else
            {
                await HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private async Task<Activity> HandleSystemMessage(Activity activity)
        {
            if (activity.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (activity.Type == ActivityTypes.ConversationUpdate)
            {
                if (activity.MembersAdded.Any(o => o.Id == activity.Recipient.Id))
                {
                    activity.Text = "action:0";
                    using (var scope = DialogModule.BeginLifetimeScope(_scope, activity))
                    {
                        await Conversation.SendAsync(activity, () => scope.Resolve<IDialog<object>>());
                    }
                }
            }
            else if (activity.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
                activity.Text = "action:0";
                using (var scope = DialogModule.BeginLifetimeScope(_scope, activity))
                {
                    await Conversation.SendAsync(activity, () => scope.Resolve<IDialog<object>>());
                }
            } 
            else if (activity.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (activity.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
}
}