﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Platform.Entity
{
    public class EntityBase : Entity<int>,ISoftDelete,IHasCreationTime
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        [Required]
        public virtual DateTime CreationTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        [Required]
        [MaxLength(20)]
        public virtual string CreateName { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public virtual DateTime? ModifyTime { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        [MaxLength(20)]
        public virtual string ModifyName { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        public virtual bool IsDeleted { get; set; }
    }
}
