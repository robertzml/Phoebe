using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoebe.WebAPI.Model
{
    using Phoebe.Core.Entity;

    /// <summary>
    /// 搬运入库接单模型
    /// </summary>
    public class CarryInReceiveModel
    {
        public string TrayCode;

        public int UserId;
    }

    /// <summary>
    /// 搬运入库上架模型
    /// </summary>
    public class CarryInEnterModel
    {
        public string TrayCode;

        public string ShelfCode;

        public int UserId;
    }

    /// <summary>
    /// 搬运入库确认模型
    /// </summary>
    public class CarryInFinishModel
    {
        public string TaskId;

        public int UserId;

        public string Remark;
    }

    /// <summary>
    /// 出库添加模型
    /// </summary>
    public class StockOutCreateModel
    {
        public StockOut stockOut;

        public List<StockOutTask> tasks;
    }

    /// <summary>
    /// 搬运出库接单模型
    /// </summary>
    public class CarryOutReceiveModel
    {
        public string TrayCode;

        public int UserId;
    }

    /// <summary>
    /// 搬运出库下架模型
    /// </summary>
    public class CarryOutLeaveModel
    {
        public string TaskCode;

        public string TrayCode;

        public string ShelfCode;

        public int UserId;
    }

    /// <summary>
    /// 搬运出库确认模型
    /// </summary>
    public class CarryOutFinishModel
    {
        public string TaskId;

        public int UserId;

        public string Remark;
    }
}
