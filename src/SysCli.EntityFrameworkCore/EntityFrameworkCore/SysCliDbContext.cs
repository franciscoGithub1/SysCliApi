using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using SysCli.Authorization.Roles;
using SysCli.Authorization.Users;
using SysCli.MultiTenancy;

namespace SysCli.EntityFrameworkCore
{
    public class SysCliDbContext : AbpZeroDbContext<Tenant, Role, User, SysCliDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public SysCliDbContext(DbContextOptions<SysCliDbContext> options)
            : base(options)
        {
        }
    }
}
