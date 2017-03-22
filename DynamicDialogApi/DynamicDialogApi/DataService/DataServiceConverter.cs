using DynamicDialogApi.DataService;
using DynamicDialogCore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace DynamicDialogBotEF.Data
{
    public class DataServiceConverter
    {
        private DynamicDialogBotDbContext _dbContext;

        public DataServiceConverter(DynamicDialogBotDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Config GetConfig(string languageId)
        {
            var dbConfig = _dbContext.GetConfig();
            if (dbConfig != null)
            {
                return new Config()
                {
                    StartAction = GetAction(dbConfig.StartActionId, languageId),
                    DefaultAction = GetAction(dbConfig.DefaultActionId, languageId),
                    DefaultResponse = GetResponse(dbConfig.DefaultResponseId, languageId),
                    ErrorResponse = GetResponse(dbConfig.ErrorResponseId, languageId),
                    ReplayResponse = GetResponse(dbConfig.ReplayResponseId, languageId),
                };
            }
            else
                return null;
        }

        public Response GetResponse(string responseId, string languageId)
        {
            var dbResponse = _dbContext.GetResponse(responseId);
            return (dbResponse != null ? new Response()
            {
                Id = dbResponse.Id,
                MediaType = dbResponse.MediaType,
                IncludeDefaultAction = dbResponse.IncludeDefaultAction,
                Slug = dbResponse.Slug,
                Texts = GetTextArray(dbResponse.TextId, languageId),
                Actions = GetActions(responseId, languageId),
                SearchHitText = GetText(dbResponse.SearchHitTextId, languageId),
                Image = GetImage(dbResponse.ImageId, languageId),
                Link = GetLink(dbResponse.LinkId, languageId),
                Video = GetLink(dbResponse.VideoId, languageId)
            }
            : null);
        }

        private string GetText(string id, string languageId)
        {
            var dbText = _dbContext.GetText(id, languageId);           
            return (dbText != null ? dbText.Content : null);
        }

        private List<string> GetTextArray(string id, string languageId)
        {
            var dbText = _dbContext.GetText(id, languageId);
            return (dbText != null ?
                new List<string>(dbText.Content.Split(new string[] { "##" }, StringSplitOptions.RemoveEmptyEntries)) : null);
        }

        private List<DynamicDialogCore.Models.DTO.Action> GetActions(string responseId, string languageId)
        {
            var actions = new List<DynamicDialogCore.Models.DTO.Action>();
            var dbResponseActions = _dbContext.GetActionsForResponse(responseId).ToList();
            foreach (var dbResponseAction in dbResponseActions)
            {
                actions.Add(GetAction(dbResponseAction.ActionId, languageId));
            }

            return actions;
        }

        private DynamicDialogCore.Models.DTO.Action GetAction(string actionId, string languageId)
        {
            var dbAction = _dbContext.GetAction(actionId);
            if (dbAction != null)
            {
                return new DynamicDialogCore.Models.DTO.Action()
                {
                    Id = dbAction.Id,
                    Slug = dbAction.Slug,
                    Text = GetText(dbAction.TextId, languageId),
                    ShortActionText = GetText(dbAction.ShortActionTextId, languageId),
                    NextResponseId = dbAction.NextResponseId,
                    Image = GetImage(dbAction.ImageId, languageId),
                    SideEffects = new List<string> { dbAction.SideEffects },
                    TrackingTags = new List<string> { dbAction.TrackingTags }
                };
            }
            else
                return null;
        }

        private Image GetImage(string id, string languageId)
        {
            var dbImage = _dbContext.GetImage(id, languageId);
            return (dbImage != null ? new Image()
            {
                Id = dbImage.Id,
                Url = dbImage.Url,
                IsAnimated = dbImage.IsAnimated
            }
            : null);
        }

        private Link GetLink(string id, string languageId)
        {
            var dbLink = _dbContext.GetLink(id, languageId);
            return (dbLink != null ? new Link()
            {
                Id = dbLink.Id,
                Url = dbLink.Url,
                Thumbnail = dbLink.ThumbnailUrl,
                Title = dbLink.Title
            }
            : null);
        }
    }
}
