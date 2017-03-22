using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDialogApi.Models.Data
{
    public class DbResponse
    {
        public string Id { get; set; }
        public string MediaType { get; set; }
        public string TextId { get; set; }
        public string SearchHitTextId { get; set; }
        public string Slug { get; set; }
        public bool IncludeDefaultAction { get; set; }
        public string ImageId { get; set; }
        public string VideoId { get; set; }
        public string LinkId { get; set; }
    }
}
