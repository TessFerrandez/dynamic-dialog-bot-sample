using DynamicDialogCore.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicDialogApi.Interfaces
{
    public interface IRepository
    {
        Response GetResponse(string id, string language);
        Config GetConfig(string language);
    }
}
