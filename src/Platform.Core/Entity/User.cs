using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Platform.Entity
{
    /// <summary>
    /// 用户表
    /// </summary>
    [Table("User")]
    public class User:EntityBase
    {
        /// <summary>
        /// 昵称
        /// </summary>
        [MaxLength(20)]
        public virtual string NiceName { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        [MaxLength(100)]
        public virtual string Header { get; set; }
        /// <summary>
        /// 手机
        /// </summary>
        [MaxLength(20)]
        public virtual string Phone { get; set; }
        /// <summary>
        /// 微信
        /// </summary>
        [MaxLength(30)]
        public virtual string WeiXin { get; set; }
        /// <summary>
        /// QQ
        /// </summary>
        [MaxLength(30)]
        public virtual string QQ { get; set; }
        /// <summary>
        /// 工号
        /// </summary>
        [MaxLength(20)]
        [Required]
        public virtual string WorkNumber { get; set; }
        /// <summary>
        /// 真实名字
        /// </summary>
        [MaxLength(20)]
        [Required]
        public virtual string RealName { get; set; }
        /// <summary>
        /// 微信OpenID
        /// </summary>
        [MaxLength(50)]
        public virtual string OpenID { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        [MaxLength(30)]
        public virtual string CompanyName { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        [MaxLength(30)]
        public virtual string DepartmentName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public virtual int Status { get; set; }

        public User()
        {
            CreationTime = DateTime.Now;
            ModifyTime = DateTime.Now;
            IsDeleted = false;
        }
    }
}
