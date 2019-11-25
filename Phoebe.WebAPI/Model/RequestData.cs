using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoebe.WebAPI.Model
{
    using Phoebe.Core.Entity;

    /// <summary>
    /// 入库接收模型
    /// </summary>
    public class StockInReceiveModel
    {
        public string TrayCode;

        public int UserId;
    }

    /// <summary>
    /// 入库上架模型
    /// </summary>
    public class StockInEnterModel
    {
        public string TrayCode;

        public string ShelfCode;

        public int UserId;
    }

    /// <summary>
    /// 入库确认模型
    /// </summary>
    public class StockInFinishModel
    {
        public string TaskId;

        public string CargoId;

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
}
