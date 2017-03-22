using DynamicDialogApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DynamicDialogCore.Models.DTO;
using DynamicDialogBotEF.Data;

namespace DynamicDialogApi.DataService
{
    public class EntityFrameworkRepository : IRepository
    {
        private DynamicDialogBotDbContext _dbContext;

        public EntityFrameworkRepository(DynamicDialogBotDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Config GetConfig(string language)
        {
            return new DataServiceConverter(_dbContext).GetConfig(language);
        }

        public Response GetResponse(string id, string language)
        {
            return new DataServiceConverter(_dbContext).GetResponse(id, language);
        }
    }
}
