using Platform.Configuration;
using Platform.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Platform.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class PlatformDbContextFactory : IDesignTimeDbContextFactory<PlatformDbContext>
    {
        public PlatformDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<PlatformDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(PlatformConsts.ConnectionStringName)
            );

            return new PlatformDbContext(builder.Options);
        }
    }
}