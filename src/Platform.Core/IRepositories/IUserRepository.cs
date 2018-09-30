using Abp.Domain.Repositories;
using Platform.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.IRepositories
{
    public interface IUserRepository :IRepository<User>
    {
    }
}
