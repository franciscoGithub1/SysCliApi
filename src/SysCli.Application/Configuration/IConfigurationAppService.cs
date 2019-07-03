using System.Threading.Tasks;
using SysCli.Configuration.Dto;

namespace SysCli.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
