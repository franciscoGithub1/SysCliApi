using Abp.Authorization;
using SysCli.Authorization.Roles;
using SysCli.Authorization.Users;

namespace SysCli.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
