using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Base.Framework
{
    /// <summary>
    /// 基础对象接口
    /// </summary>
    /// <typeparam name="Tkey"></typeparam>
    public interface IBaseEntity<Tkey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        Tkey Id { get; set; }
    }
}
