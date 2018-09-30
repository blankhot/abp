using System;
using System.Threading.Tasks;
using Abp.TestBase;
using Platform.EntityFrameworkCore;
using Platform.Tests.TestDatas;

namespace Platform.Tests
{
    public class PlatformTestBase : AbpIntegratedTestBase<PlatformTestModule>
    {
        public PlatformTestBase()
        {
            UsingDbContext(context => new TestDataBuilder(context).Build());
        }

        protected virtual void UsingDbContext(Action<PlatformDbContext> action)
        {
            using (var context = LocalIocManager.Resolve<PlatformDbContext>())
            {
                action(context);
                context.SaveChanges();
            }
        }

        protected virtual T UsingDbContext<T>(Func<PlatformDbContext, T> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<PlatformDbContext>())
            {
                result = func(context);
                context.SaveChanges();
            }

            return result;
        }

        protected virtual async Task UsingDbContextAsync(Func<PlatformDbContext, Task> action)
        {
            using (var context = LocalIocManager.Resolve<PlatformDbContext>())
            {
                await action(context);
                await context.SaveChangesAsync(true);
            }
        }

        protected virtual async Task<T> UsingDbContextAsync<T>(Func<PlatformDbContext, Task<T>> func)
        {
            T result;

            using (var context = LocalIocManager.Resolve<PlatformDbContext>())
            {
                result = await func(context);
                context.SaveChanges();
            }

            return result;
        }
    }
}
