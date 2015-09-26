using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Model
{
    /// <summary>
    /// 计费记录
    /// </summary>
    public class ChargeRecord
    {
        /// <summary>
        /// 入库日期
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime RecordDate { get; set; }

        /// <summary>
        /// 货品名称
        /// </summary>
        public string CargoName { get; set; }

        /// <summary>
        /// 单位重量(kg)
        /// </summary>
        public double UnitWeight { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        ///  总重量(t)
        /// </summary>
        public double TotalWeight { get; set; }
    }
}
