using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SysCli.MultiTenancy.Dto;

namespace SysCli.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

