using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.Common
{
    public class GlobalSettings
    {
        public GlobalSettings()
        {
        }
        /// <summary>
        /// AES加解密Key
        /// </summary>
        public string AESKey { get; set; }

        /// <summary>
        /// 默认密码
        /// </summary>
        public string DefaultPwd { get; set; }

        /// <summary>
        /// 是否正式
        /// </summary>
        public bool IsRelease { get; set; }
    }
}
