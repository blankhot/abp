using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.Entity
{
    public class UserRole: Entity<int>
    {
        public virtual string UserId { get; set; }

        public virtual string RoleId { get; set; }
    }
}
