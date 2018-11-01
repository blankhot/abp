using Platform.Common.DtoTool;
using System;
using System.Collections.Generic;
using System.Text;

namespace Platform.UserService.Dtos
{
    public class UserPageInput:PageBaseInput
    {
        public virtual string Name { get; set; }
    }
}
