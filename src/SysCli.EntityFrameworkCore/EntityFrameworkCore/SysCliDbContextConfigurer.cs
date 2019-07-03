using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace SysCli.EntityFrameworkCore
{
    public static class SysCliDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<SysCliDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<SysCliDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
