using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;
using Phoebe.UI.Filters;
using Phoebe.UI.Services;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 合同控制器
    /// </summary>
    [EnhancedAuthorize]
    public class ContractController : Controller
    {
        #region Field
        /// <summary>
        /// 合同业务
        /// </summary>
        private ContractBusiness contractBusiness;
        #endregion //Field

        #region Constructor
        public ContractController()
        {
            this.contractBusiness = new ContractBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 合同主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.contractBusiness.GetNormal();
            return View(data);
        }

        /// <summary>
        /// 合同信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var data = this.contractBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 合同信息
        /// </summary>
        /// <param name="id">合同ID</param>
        /// <returns></returns>
        public ActionResult DetailsModal(int id)
        {
            var data = this.contractBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Contract model)
        {
            if (ModelState.IsValid)
            {
                CustomerBusiness customerBusiness = new CustomerBusiness();
                if (model.CustomerType == 1)
                {
                    var cus = customerBusiness.GetGroupCustomer(model.CustomerID);
                    if (cus == null)
                    {
                        TempData["Message"] = "签订合同失败";
                        ModelState.AddModelError("", "签订合同失败: 客户不存在");
                        return View(model);
                    }
                }
                else
                {
                    var cus = customerBusiness.GetScatterCustomer(model.CustomerID);
                    if (cus == null)
                    {
                        TempData["Message"] = "签订合同失败";
                        ModelState.AddModelError("", "签订合同失败: 客户不存在");
                        return View(model);
                    }
                }

                var user = PageService.GetCurrentUser(User.Identity.Name);
                model.UserID = user.ID;

                ErrorCode result = this.contractBusiness.Create(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "签订合同成功";
                    return RedirectToAction("Details", new { controller = "Contract", id = model.ID });
                }
                else
                {
                    TempData["Message"] = "签订合同失败";
                    ModelState.AddModelError("", "签订合同失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 关闭合同
        /// </summary>
        /// <param name="id">合同ID</param>
        /// <returns></returns>
        public ActionResult Close(int id)
        {
            this.contractBusiness.Close(id);
            return RedirectToAction("Details", new { controller = "Contract", id = id });
        }

        /// <summary>
        /// 合同列表
        /// </summary>
        /// <param name="type">类型</param>
        /// <returns></returns>
        public ActionResult List(int type)
        {
            if (type == 2) // closed contract
            {
                ViewBag.Title = "已关闭合同";
                var data = this.contractBusiness.GetByType(EntityStatus.ContractClosed);
                return View(data);
            }
            else
            {
                return HttpNotFound();
            }
        }
        #endregion //Action

        #region Json
        /// <summary>
        /// 获取客户
        /// </summary>
        /// <param name="type">客户类型</param>
        /// <remarks>
        /// 调用：
        /// /Contract/Create
        /// </remarks>
        /// <returns></returns>
        public JsonResult GetCustomers(int type)
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();
            if (type == 1)
            {
                var data = customerBusiness.GetGroupCustomer();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var data = customerBusiness.GetScatterCustomer();
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 获取相关合同
        /// </summary>
        /// <param name="type">相关类型</param>
        /// <remarks>
        /// 调用：
        /// /StockIn/Create
        /// /StockOut/Create
        /// </remarks>
        /// <returns></returns>
        public JsonResult GetContracts(int type)
        {
            CargoBusiness cargoBusiness = new CargoBusiness();

            if (type == 0)
            {
                var contracts = cargoBusiness.GetWithUnStockIn();
                var data = from r in contracts
                           select new { r.ID, r.Name, r.Number };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else if (type == 1)
            {
                var contracts = cargoBusiness.GetWithHasStock();
                var data = from r in contracts
                           select new { r.ID, r.Name, r.Number };

                return Json(data, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return null;
            }
        }
        #endregion //Json
    }
}