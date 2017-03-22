using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDialogApi.Models.Data
{
    public class DbImage
    {
        public string Id { get; set; }
        public string LanguageId { get; set; }
        public string Url { get; set; }
        public bool IsAnimated { get; set; }
    }
}
