using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SysCli.Controllers
{
    public abstract class SysCliControllerBase: AbpController
    {
        protected SysCliControllerBase()
        {
            LocalizationSourceName = SysCliConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
