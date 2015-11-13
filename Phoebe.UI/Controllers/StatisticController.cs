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
        #region Field
        /// <summary>
        /// 货品业务
        /// </summary>
        private StatisticBusiness statisticBusienss;
        #endregion //Field

        #region Constructor
        public StatisticController()
        {
            this.statisticBusienss = new StatisticBusiness();
        }
        #endregion ///Constructor

        #region Action
        /// <summary>
        /// 客户流水统计
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerFlow()
        {
            return View();
        }

        /// <summary>
        /// 客户流水统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CustomerFlowResult(CustomerFlowInput model)
        {
            if (ModelState.IsValid)
            {
                var data = this.statisticBusienss.GetFlowByCustomer(model.CustomerType, model.CustomerID, model.DateFrom.Date, model.DateTo.Date);

                return View(data);
            }
            else
            {
                return View("CustomerFlow", model);
            }
        }

        /// <summary>
        /// 客户库存统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CustomerStore()
        {
            return View();
        }

        /// <summary>
        /// 客户库存统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CustomerStoreResult(CustomerStoreInput model)
        {
            if (ModelState.IsValid)
            {
                var data = this.statisticBusienss.GetStoreByCustomer(model.CustomerType, model.CustomerID, model.Date.Date);

                ViewBag.ClassifyStore = this.statisticBusienss.ConvertToClassify(data);

                return View(data);
            }
            else
            {
                return View("CustomerStore", model);
            }
        }

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
        public ActionResult ContractStoreResult(StoreSnapshootInput model)
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
        /// 库存分类汇总
        /// </summary>
        /// <returns></returns>
        public ActionResult CategorySummary()
        {
            return View();
        }

        /// <summary>
        /// 库存分类汇总
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CategorySummaryResult(CategorySummaryInput model)
        {
            if (ModelState.IsValid)
            {
                var data = this.statisticBusienss.GetStoreCategorySummary(model.FirstCategoryID, model.SecondCategoryID);

                CategoryBusiness categoryBusiness = new CategoryBusiness();
                ViewBag.SecondCategoryName = categoryBusiness.GetSecondCategory(model.SecondCategoryID).Name;

                return View(data);
            }
            else
            {
                return View("CategorySummary", model);
            }
        }

        /// <summary>
        /// 库存流水汇总
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CategoryFlow()
        {
            return View();
        }

        /// <summary>
        /// 库存流水汇总
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CategoryFlowResult(CategoryFlowInput model)
        {
            if (ModelState.IsValid)
            {
                var data = this.statisticBusienss.GetStoreCategoryFlow(model.FirstCategoryID, model.SecondCategoryID, model.DateFrom, model.DateTo);

                return View(data);
            }
            else
            {
                return View("CategoryFlow", model);
            }
        }

        /// <summary>
        /// 收款统计
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ReceiptSummary()
        {
            return View();
        }

        /// <summary>
        /// 收款统计
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ReceiptSummaryResult(PaidSummaryInput model)
        {
            if (ModelState.IsValid)
            {
                var data = this.statisticBusienss.GetReceiptRecords(model.DateFrom.Date, model.DateTo.Date);

                return View(data);
            }
            else
            {
                return View("ReceiptSummary", model);
            }
        }

        #region Partial
        /// <summary>
        /// 按客户获取分类库存
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public ActionResult GetClassifyStoreByCustomer(int customerType, int customerID)
        {
            var data = this.statisticBusienss.GetClassifyStoreByCustomer(customerType, customerID);

            return View(data);
        }

        /// <summary>
        /// 按客户获取付款统计
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public ActionResult GetPaidSettleByCustomer(int customerType, int customerID)
        {
            var data = this.statisticBusienss.GetPaidSettleByCustomer(customerType, customerID);

            return View(data);
        }
        #endregion //Partial
        #endregion //Action
    }
}