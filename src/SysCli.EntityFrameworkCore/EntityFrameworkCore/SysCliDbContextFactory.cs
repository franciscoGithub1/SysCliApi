using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SysCli.Configuration;
using SysCli.Web;

namespace SysCli.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class SysCliDbContextFactory : IDesignTimeDbContextFactory<SysCliDbContext>
    {
        public SysCliDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<SysCliDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            SysCliDbContextConfigurer.Configure(builder, configuration.GetConnectionString(SysCliConsts.ConnectionStringName));

            return new SysCliDbContext(builder.Options);
        }
    }
}
