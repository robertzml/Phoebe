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
        ///  重量累计(t)
        /// </summary>
        public decimal TotalWeight { get; set; }

        /// <summary>
        /// 日冷藏费(元)
        /// </summary>
        public decimal DailyFee { get; set; }

        /// <summary>
        /// 冷藏费累计(元)
        /// </summary>
        public decimal TotalFee { get; set; }
    }
}
