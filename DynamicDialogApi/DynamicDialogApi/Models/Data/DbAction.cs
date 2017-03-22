using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDialogApi.Models.Data
{
    public class DbAction
    {
        public string Id { get; set; }
        public string ImageId { get; set; }
        public string TextId { get; set; }
        public string ShortActionTextId { get; set; }
        public string Slug { get; set; }
        public string SideEffects { get; set; }
        public string TrackingTags { get; set; }
        public string NextResponseId { get; set; }
    }
}
