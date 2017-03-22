using System;

namespace DynamicDialogCore.Models.DTO
{
#if !(NETCOREAPP1_0)
    [Serializable]
#endif
    public class Link
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public string Thumbnail { get; set; }
        public string Title { get; set; }
    }

}
