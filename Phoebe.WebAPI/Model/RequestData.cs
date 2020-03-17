using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phoebe.WebAPI.Model
{
    using Phoebe.Core.Entity;
    using Phoebe.Core.Model;

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

        [Required]
        public string TrayCode;

        [Required]
        public int MoveCount;

        [Required]
        public decimal MoveWeight;

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
        public int UserId;
    }

    /// <summary>
    /// 出库添加仓位库出库货物
    /// </summary>
    public class StockOutAddPositionModel
    {
        [Required]
        public string StockOutId;

        [Required]
        public int UserId;

        [Required]
        public List<CarryOutTask> Tasks;
    }

    /// <summary>
    /// 出库添加普通库出库货物
    /// </summary>
    public class StockOutAddNormalModel
    {
        [Required]
        public string StockOutId;

        [Required]
        public int UserId;

        [Required]
        public List<NormalStockOutTask> Tasks;
    }

    /// <summary>
    /// 出库单提交搬运出库模型
    /// </summary>
    public class StockOutTaskAddCarryOutModel
    {
        [Required]
        public string StockOutId;

        [Required]
        public string TrayCode;

        [Required]
        public int UserId;

        [Required]
        public List<CarryOutTask> Tasks;
    }

    /// <summary>
    /// 入库任务提交搬运出库模型
    /// </summary>
    public class StockInTaskAddCarryOutModel
    {
        [Required]
        public string StockInTaskId;

        [Required]
        public string TrayCode;

        [Required]
        public int UserId;

        [Required]
        public List<CarryOutTask> Tasks;
    }

    /// <summary>
    /// 日冷藏费清单模型
    /// </summary>
    public class DailyColdFeeModel
    {
        [Required]
        public int CustomerId;

        [Required]
        public int ContractId;

        [Required]
        public DateTime StartTime;

        [Required]
        public DateTime EndTime;
    }
}
