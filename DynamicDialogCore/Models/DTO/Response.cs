using System;
using System.Collections.Generic;

namespace DynamicDialogCore.Models.DTO
{
#if !(NETCOREAPP1_0)
    [Serializable]
#endif
    public class Response
    {
        public string Id { get; set; }
        public string MediaType { get; set; }
        public List<string> Texts { get; set; }
        public string SearchHitText { get; set; }
        public List<Action> Actions { get; set; }
        public string Slug { get; set; }
        public bool IncludeDefaultAction { get; set; }
        public Image Image { get; set; }
        public Link Video { get; set; }
        public Link Link { get; set; }
    }

}
