//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Phoebe.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int UserGroupID { get; set; }
        public string Name { get; set; }
        public System.DateTime LastLoginTime { get; set; }
        public System.DateTime CurrentLoginTime { get; set; }
        public string Remark { get; set; }
        public int Status { get; set; }
    
        public virtual UserGroup UserGroup { get; set; }
    }
}
