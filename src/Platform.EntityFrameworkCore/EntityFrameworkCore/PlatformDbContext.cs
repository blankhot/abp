using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Platform.EntityFrameworkCore
{
    public class PlatformDbContext : AbpDbContext
    {
        //Add DbSet properties for your entities...

        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) 
            : base(options)
        {

        }
    }
}
