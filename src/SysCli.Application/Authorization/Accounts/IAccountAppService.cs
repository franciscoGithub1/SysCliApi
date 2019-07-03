using System.Threading.Tasks;
using Abp.Application.Services;
using SysCli.Authorization.Accounts.Dto;

namespace SysCli.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
