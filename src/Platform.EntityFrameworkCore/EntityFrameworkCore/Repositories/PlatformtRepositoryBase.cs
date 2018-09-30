using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Platform.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.EntityFrameworkCore.Repositories
{
    public abstract class PlatformRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<PlatformDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected PlatformRepositoryBase(IDbContextProvider<PlatformDbContext> dbContextProvider)
           : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class PlatformRepositoryBase<TEntity> : PlatformRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected PlatformRepositoryBase(IDbContextProvider<PlatformDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
