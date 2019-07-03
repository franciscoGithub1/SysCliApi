using System.Threading.Tasks;
using Abp.Application.Services;
using SysCli.Sessions.Dto;

namespace SysCli.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
