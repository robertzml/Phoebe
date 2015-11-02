using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Model;
using Phoebe.UI.Filters;
using Phoebe.UI.Models;
using Phoebe.UI.Services;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 统计控制器
    /// </summary>
    [EnhancedAuthorize]
    public class StatisticController : Controller
    {
        #region Action
        /// <summary>
        /// 合同流水统计
        /// </summary>
        /// <returns></returns>
        public ActionResult ContractFlow()
        {
            return View();
        }

        /// <summary>
        /// 合同流水统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ContractFlowResult(ContractFlowInput model)
        {
            if (ModelState.IsValid)
            {
                List<StockFlow> data = new List<StockFlow>();

                StoreBusiness storeBusiness = new StoreBusiness();

                for (DateTime step = model.DateFrom.Date; step <= model.DateTo; step = step.AddDays(1))
                {
                    var flows = storeBusiness.GetDaysFlow(model.ContractID, step);
                    data.AddRange(flows);
                }

                return View(data);
            }
            else
            {
                return View("ContractFlow", model);
            }
        }

        /// <summary>
        /// 合同库存统计
        /// </summary>
        /// <returns></returns>
        public ActionResult ContractStore()
        {
            return View();
        }

        /// <summary>
        /// 合同库存统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ContractStoreProcess(StoreSnapshootInput model)
        {
            if (ModelState.IsValid)
            {
                StoreBusiness storeBusiness = new StoreBusiness();

                var data = storeBusiness.GetInDay(model.ContractID, model.Date);
                return View(data);
            }
            else
            {
                return View("ContractStore", model);
            }
        }

        /// <summary>
        /// 库存汇总
        /// </summary>
        /// <returns></returns>
        public ActionResult StoreSummary()
        {
            return View();
        }

        /// <summary>
        /// 库存汇总
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult StoreSummaryProcess(StoreSummaryInput model)
        {
            if (ModelState.IsValid)
            {
                ContractBusiness contractBusiness = new ContractBusiness();
                StoreBusiness storeBusiness = new StoreBusiness();

                List<Storage> data = new List<Storage>();
                var contracts = contractBusiness.Get();

                foreach (var item in contracts)
                {
                    var s = storeBusiness.GetInDay(item.ID, model.Date);
                    data.AddRange(s);
                }

                return View(data);
            }
            else
            {
                return View("StoreSummary", model);
            }
        }

        /// <summary>
        /// 按客户获取分类库存
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public ActionResult GetClassifyStoreByCustomer(int customerType, int customerID)
        {
            StatisticBusiness statisticBusienss = new StatisticBusiness();
            var data = statisticBusienss.GetClassifyStoreByCustomer(customerType, customerID);

            return View(data);
        }
        #endregion //Action
    }
}