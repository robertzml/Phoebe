using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phoebe.WebAPI.Model
{
    /// <summary>
    /// 搬运入库新增模型
    /// </summary>
    public class CarryInCreateModel
    {
        [Required]
        public string StockInTaskId;

        [Required]
        public string TrayCode;

        [Required]
        public int MoveCount;

        [Required]
        public decimal MoveWeight;

        [Required]
        public int CheckUserId;

        public string Remark;
    }

    /// <summary>
    /// 搬运入库接单模型
    /// </summary>
    public class CarryInReceiveModel
    {
        [Required]
        public string TrayCode;

        [Required]
        public int UserId;
    }

    /// <summary>
    /// 搬运入库上架模型
    /// </summary>
    public class CarryInEnterModel
    {
        [Required]
        public string TrayCode;

        [Required]
        public string ShelfCode;

        [Required]
        public int UserId;
    }

    /// <summary>
    /// 搬运入库确认模型
    /// </summary>
    public class CarryInFinishModel
    {
        [Required]
        public string TaskId;

        [Required]
        public int UserId;

        public string Remark;
    }

    /// <summary>
    /// 搬运出库接单模型
    /// </summary>
    public class CarryOutReceiveModel
    {
        [Required]
        public string TrayCode;

        [Required]
        public int UserId;
    }

    /// <summary>
    /// 搬运出库下架模型
    /// </summary>
    public class CarryOutLeaveModel
    {
        [Required]
        public string TrayCode;

        [Required]
        public string ShelfCode;

        [Required]
        public int UserId;
    }

    /// <summary>
    /// 搬运出库确认模型
    /// </summary>
    public class CarryOutFinishModel
    {
        [Required]
        public string TaskId;

        [Required]
        public int MoveCount;

        [Required]
        public decimal MoveWeight;

        [Required]
        public int UserId;

        public string Remark;
    }
}
