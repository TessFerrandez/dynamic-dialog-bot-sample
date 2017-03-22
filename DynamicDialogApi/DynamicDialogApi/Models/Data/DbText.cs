using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDialogApi.Models.Data
{
    public class DbText
    {
        public string Id { get; set; }
        public string LanguageId { get; set; }
        public int Ordinal { get; set; }
        public string Content { get; set; }
    }
}
