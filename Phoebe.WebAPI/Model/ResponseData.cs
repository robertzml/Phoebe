using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoebe.WebAPI.Model
{
    /// <summary>
    /// 返回数据
    /// </summary>
    public class ResponseData
    {
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// 错误消息
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// 对象
        /// </summary>
        public object Entity { get; set; }
    }
}
