using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Platform.Entity
{
    [Table("Role")]
    public class Role:EntityBase
    {
        public virtual string RoleName { get; set; }

        public virtual bool IsStaticRole { get; set; }

        public virtual bool IsDefaultRole { get; set; }

        public virtual bool IsEnabled { get; set; }
    }
}
