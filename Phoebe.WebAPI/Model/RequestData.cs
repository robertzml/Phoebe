using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoebe.WebAPI.Model
{
    using Phoebe.Core.Entity;

    /// <summary>
    /// 出库添加模型
    /// </summary>
    public class StockOutCreateModel
    {
        public StockOut stockOut;

        public List<StockOutTask> tasks;
    }
}
