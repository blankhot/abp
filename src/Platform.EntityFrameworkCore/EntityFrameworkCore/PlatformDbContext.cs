using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Platform.Entity;

namespace Platform.EntityFrameworkCore
{
    public class PlatformDbContext : AbpDbContext
    {
        public DbSet<User> Users { get; set; }

        //Add DbSet properties for your entities...

        public PlatformDbContext(DbContextOptions<PlatformDbContext> options) 
            : base(options)
        {

        }
    }
}
