using DynamicDialogCore.Models.DTO;
using System.Threading.Tasks;

namespace DynamicDialogBot.Services
{
    public interface IResponseService
    {
        Task<Config> GetConfigAsync(string language);

        Task<Response> GetResponseAsync(string responseId, string language);
    }
}