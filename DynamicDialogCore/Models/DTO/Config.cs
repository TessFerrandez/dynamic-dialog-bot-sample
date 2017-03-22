using System;

namespace DynamicDialogCore.Models.DTO
{
#if !(NETCOREAPP1_0)
    [Serializable]
#endif
    public class Config
    {
        public Action StartAction { get; set; }
        public Action DefaultAction { get; set; }
        public Response DefaultResponse { get; set; }
        public Response ReplayResponse { get; set; }
        public Response ErrorResponse { get; set; }
    }
}
