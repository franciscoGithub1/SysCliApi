using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SysCli.Configuration.Dto;

namespace SysCli.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SysCliAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
