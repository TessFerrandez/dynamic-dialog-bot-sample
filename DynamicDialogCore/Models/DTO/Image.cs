using System;

namespace DynamicDialogCore.Models.DTO
{
#if !(NETCOREAPP1_0)
    [Serializable]
#endif
    public class Image
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public bool IsAnimated { get; set; }
    }

}
