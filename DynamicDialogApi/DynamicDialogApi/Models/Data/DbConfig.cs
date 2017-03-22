using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDialogApi.Models.Data
{
    public class DbConfig
    {
        public string Id { get; set; }
        public string StartActionId { get; set; }
        public string DefaultActionId { get; set; }
        public string DefaultResponseId { get; set; }
        public string ReplayResponseId { get; set; }
        public string ErrorResponseId { get; set; }
    }

}
