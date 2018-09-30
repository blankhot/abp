using Microsoft.EntityFrameworkCore;

namespace Platform.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<PlatformDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for PlatformDbContext */
            dbContextOptions.UseSqlServer(connectionString);
        }
    }
}
