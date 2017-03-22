using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDialogApi.Models.Data
{
    public class DbLink
    {
        public string Id { get; set; }
        public string LanguageId { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
        public string Title { get; set; }
    }
}
