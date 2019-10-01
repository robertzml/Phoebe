using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Base.System;
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 出库控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockOutController : ControllerBase
    {
        #region Common
        /// <summary>
        /// 获取月度分组
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string[] GetMonthGroup()
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            return stockOutViewBusiness.GetMonthGroup();
        }
        #endregion //Common

        #region Stock Out
        /// <summary>
        /// 获取出库列表
        /// </summary>
        /// <param name="monthTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockOutView>> List(string monthTime)
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            if (string.IsNullOrEmpty(monthTime))
            {
                return stockOutViewBusiness.FindAll();
            }
            else
            {
                return stockOutViewBusiness.FindByMonth(monthTime);
            }
        }
        #endregion //Stock Out
    }
}