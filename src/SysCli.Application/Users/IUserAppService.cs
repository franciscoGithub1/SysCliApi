using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SysCli.Roles.Dto;
using SysCli.Users.Dto;

namespace SysCli.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
