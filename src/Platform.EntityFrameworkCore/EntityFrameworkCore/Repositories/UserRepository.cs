using Abp.EntityFrameworkCore;
using Platform.Entity;
using Platform.IRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.EntityFrameworkCore.Repositories
{
    public class UserRepository : PlatformRepositoryBase<User>,IUserRepository
    {
        public UserRepository(IDbContextProvider<PlatformDbContext> dbContextProvider) : base(dbContextProvider)
        { }
    }
}
