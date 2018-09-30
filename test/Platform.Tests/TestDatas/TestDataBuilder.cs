using Platform.EntityFrameworkCore;

namespace Platform.Tests.TestDatas
{
    public class TestDataBuilder
    {
        private readonly PlatformDbContext _context;

        public TestDataBuilder(PlatformDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            //create test data here...
        }
    }
}