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
    /// 货品控制器
    /// </summary>
    [EnhancedAuthorize]
    public class CargoController : Controller
    {
        #region Field
        /// <summary>
        /// 货品业务
        /// </summary>
        private CargoBusiness cargoBusiness;
        #endregion //Field

        #region Constructor
        public CargoController()
        {
            this.cargoBusiness = new CargoBusiness();
        }
        #endregion ///Constructor

        #region Action
        /// <summary>
        /// 货品主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.cargoBusiness.Get(EntityStatus.CargoStockIn);
            return View(data);
        }

        /// <summary>
        /// 未入库货品
        /// </summary>
        /// <returns></returns>
        public ActionResult ListByNotIn()
        {
            var data1 = this.cargoBusiness.Get(EntityStatus.CargoNotIn);
            var data2 = this.cargoBusiness.Get(EntityStatus.CargoStockInReady);
            var data = data1.Union(data2);

            return View(data);
        }

        /// <summary>
        /// 已出库货品
        /// </summary>
        /// <returns></returns>
        public ActionResult ListByOut()
        {
            var data = this.cargoBusiness.Get(EntityStatus.CargoStockOut);
            return View(data);
        }

        /// <summary>
        /// 货品信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult Details(string id)
        {
            var data = this.cargoBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            TransferBusiness transferBusiness = new TransferBusiness();
            ViewBag.TransferOut = transferBusiness.GetDetailsByCargo(id, true);
            ViewBag.TransferIn = transferBusiness.GetDetailsByCargo(id, false);

            BillingBusiness billingBusiness = new BillingBusiness();
            ViewBag.TotalPrice = billingBusiness.GetTotalPrice(id);
            ViewBag.ColdPrice = billingBusiness.CalculateColdPrice(id);

            return View(data);
        }

        /// <summary>
        /// 货品信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult DetailsModal(string id)
        {
            var data = this.cargoBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 货品信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <remarks>
        /// 信息小panel
        /// </remarks>
        /// <returns></returns>
        public ActionResult Info(string id)
        {
            var data = this.cargoBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 货品登记
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            var data = new Cargo();
            data.Count = 0;
            data.UnitWeight = 0.0;
            data.UnitVolume = 0.0;
            data.RegisterTime = DateTime.Now;

            data.Billing = new Billing();
            data.Billing.IsTiming = true;
            data.Billing.HandlingPrice = 0;
            data.Billing.FreezePrice = 0;
            data.Billing.DisposePrice = 0;
            data.Billing.PackingPrice = 0;
            data.Billing.RentPrice = 0;
            data.Billing.OtherPrice = 0;

            return View(data);
        }

        /// <summary>
        /// 货品登记
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Cargo model)
        {
            if (ModelState.IsValid)
            {
                var user = PageService.GetCurrentUser(User.Identity.Name);

                model.TotalWeight = Math.Round(Convert.ToDouble(model.Count * model.UnitWeight / 1000), 3);
                model.TotalVolume = Math.Round(Convert.ToDouble(model.Count * model.UnitVolume), 3);
                model.StoreCount = model.Count;
                model.UserID = user.ID;
                if (string.IsNullOrEmpty(Request.Form["BillingType"]))
                {
                    TempData["Message"] = "货品登记失败";
                    ModelState.AddModelError("", "货品登记失败: 请选择计费方式");
                    return View(model);
                }
                model.Billing.BillingType = Convert.ToInt32(Request.Form["BillingType"]);

                if (model.Billing.BillingType == (int)BillingType.UnitWeight)
                {
                    if (model.UnitWeight == null || model.UnitWeight == 0)
                    {
                        TempData["Message"] = "货品登记失败";
                        ModelState.AddModelError("", "货品登记失败: 请输入单位重量");
                        return View(model);
                    }
                }
                else if (model.Billing.BillingType == (int)BillingType.UnitVolume)
                {
                    if (model.UnitVolume == null || model.UnitVolume == 0)
                    {
                        TempData["Message"] = "货品登记失败";
                        ModelState.AddModelError("", "货品登记失败: 请输入单位体积");
                        return View(model);
                    }
                }

                model.Billing.Status = (int)EntityStatus.BillingUnsettle;

                ErrorCode result = this.cargoBusiness.Create(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "货品登记成功";
                    return RedirectToAction("Details", new { controller = "Cargo", id = model.ID });
                }
                else
                {
                    TempData["Message"] = "货品登记失败";
                    ModelState.AddModelError("", "货品登记失败: " + result.DisplayName());
                }

            }

            return View(model);
        }

        /// <summary>
        /// 编辑货品
        /// </summary>
        /// <param name="id">货品ID</param>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "Root,Administrator")]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            var data = this.cargoBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 编辑货品
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "Root,Administrator")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(Cargo model)
        {
            if (ModelState.IsValid)
            {
                var cargo = this.cargoBusiness.Get(model.ID.ToString());

                cargo.Name = model.Name;
                cargo.FirstCategoryID = model.FirstCategoryID;
                cargo.SecondCategoryID = model.SecondCategoryID;
                cargo.ThirdCategoryID = model.ThirdCategoryID;
                cargo.Count = model.Count;
                cargo.UnitWeight = model.UnitWeight;
                cargo.UnitVolume = model.UnitVolume;
                cargo.TotalWeight = Math.Round(Convert.ToDouble(model.Count * model.UnitWeight / 1000), 3);
                cargo.TotalVolume = Math.Round(Convert.ToDouble(model.Count * model.UnitVolume), 3);
                cargo.OriginPlace = model.OriginPlace;
                cargo.Specification = model.Specification;
                cargo.ShelfLife = model.ShelfLife;
                cargo.RegisterTime = model.RegisterTime;
                cargo.Remark = model.Remark;

                ErrorCode result = this.cargoBusiness.Edit(cargo);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "编辑货品成功";
                    return RedirectToAction("Details", new { controller = "Cargo", id = cargo.ID.ToString() });
                }
                else
                {
                    TempData["Message"] = "编辑货品失败";
                    ModelState.AddModelError("", "编辑货品失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 编辑计费信息
        /// </summary>
        /// <param name="id">货品ID</param>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "Root,Administrator")]
        [HttpGet]
        public ActionResult EditBilling(string id)
        {
            BillingBusiness billingBusiness = new BillingBusiness();
            var data = billingBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }

        /// <summary>
        /// 编辑计费信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [EnhancedAuthorize(Roles = "Root,Administrator")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditBilling(Billing model)
        {
            if (ModelState.IsValid)
            {
                BillingBusiness billingBusiness = new BillingBusiness();

                ErrorCode result = billingBusiness.Edit(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "编辑计费信息成功";
                    return RedirectToAction("Details", new { controller = "Cargo", id = model.CargoID.ToString() });
                }
                else
                {
                    TempData["Message"] = "编辑计费信息失败";
                    ModelState.AddModelError("", "编辑计费信息失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action

        #region JSON
        /// <summary>
        /// 获取货品
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="contractID">所属合同</param>
        /// <remarks>
        /// 调用：
        /// /StockIn/Create
        /// /StockMove/Creat
        /// /StockOut/Create
        /// /Transfer/Create
        /// /Settle/Base
        /// /Settle/CargoColdPrice
        /// </remarks>
        /// <returns></returns>
        public JsonResult GetCargos(int type, int contractID)
        {
            IEnumerable<Cargo> cargos;
            if (type == 1)  // not stock in
            {
                cargos = this.cargoBusiness.Get(EntityStatus.CargoNotIn).Where(r => r.ContractID == contractID);
            }
            else if (type == 2) // stock in
            {
                cargos = this.cargoBusiness.Get(EntityStatus.CargoStockIn).Where(r => r.ContractID == contractID);
            }
            else if (type == 3) // all with out not in
            {
                cargos = this.cargoBusiness.GetByContract(contractID).Where(r => r.Status != (int)EntityStatus.CargoNotIn && r.Status != (int)EntityStatus.CargoStockInReady);
            }
            else if (type == 4) // get billing unsettle
            {
                cargos = this.cargoBusiness.GetByContract(contractID).Where(r => r.Billing.Status == (int)EntityStatus.BillingUnsettle);
            }
            else
            {
                return null;
            }

            var data = from r in cargos
                       select new { r.ID, r.Name };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion //JSON
    }
}