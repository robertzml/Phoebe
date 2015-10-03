using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;
using Phoebe.UI.Models;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 类别控制器
    /// </summary>
    public class CategoryController : Controller
    {
        #region Field
        /// <summary>
        /// 类别业务
        /// </summary>
        private CategoryBusiness categoryBusiness;
        #endregion //Field

        #region Constructor
        public CategoryController()
        {
            this.categoryBusiness = new CategoryBusiness();
        }
        #endregion ///Constructor

        #region Action
        /// <summary>
        /// 类别主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.categoryBusiness.GetFirstCategory();
            return View(data);
        }

        /// <summary>
        /// 分类信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        public ActionResult Info(int id, int level)
        {
            CategoryInfoModel model = new CategoryInfoModel();
            if (level == 1)
            {
                var data = this.categoryBusiness.GetFirstCategory(id);
                model.ID = id;
                model.Name = data.Name;
                model.Level = 1;
                model.Remark = data.Remark;
            }
            else if (level == 2)
            {
                var data = this.categoryBusiness.GetSecondCategory(id);
                model.ID = id;
                model.Name = data.Name;
                model.Level = 2;
                model.Remark = data.Remark;
            }
            else if (level == 3)
            {
                var data = this.categoryBusiness.GetThirdCategory(id);
                model.ID = id;
                model.Name = data.Name;
                model.Level = 3;
                model.Remark = data.Remark;
            }
            else
            {
                return HttpNotFound();
            }

            return View(model);
        }

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateFirstCategory()
        {
            return View();
        }

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateFirstCategory(FirstCategory model)
        {
            if (ModelState.IsValid)
            {
                ErrorCode result = this.categoryBusiness.CreateFirstCategory(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加一级分类成功";
                    return RedirectToAction("Index", new { controller = "Category" });
                }
                else
                {
                    TempData["Message"] = "添加一级分类失败";
                    ModelState.AddModelError("", "添加一级分类失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 添加二级分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateSecondCategory()
        {
            return View();
        }

        /// <summary>
        /// 添加二级分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateSecondCategory(SecondCategory model)
        {
            if (ModelState.IsValid)
            {
                ErrorCode result = this.categoryBusiness.CreateSecondCategory(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加二级分类成功";
                    return RedirectToAction("Index", new { controller = "Category" });
                }
                else
                {
                    TempData["Message"] = "添加二级分类失败";
                    ModelState.AddModelError("", "添加二级分类失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 添加三级分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult CreateThirdCategory()
        {
            return View();
        }

        /// <summary>
        /// 添加三级分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CreateThirdCategory(ThirdCategory model)
        {
            if (ModelState.IsValid)
            {
                ErrorCode result = this.categoryBusiness.CreateThirdCategory(model);
                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "添加三级分类成功";
                    return RedirectToAction("Index", new { controller = "Category" });
                }
                else
                {
                    TempData["Message"] = "添加三级分类失败";
                    ModelState.AddModelError("", "添加三级分类失败: " + result.DisplayName());
                }
            }

            return View(model);
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="level">级别</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int id, int level)
        {
            CategoryInfoModel model = new CategoryInfoModel();
            if (level == 1)
            {
                var data = this.categoryBusiness.GetFirstCategory(id);
                model.ID = id;
                model.Name = data.Name;
                model.Level = 1;
                model.Remark = data.Remark;
            }
            else if (level == 2)
            {
                var data = this.categoryBusiness.GetSecondCategory(id);
                model.ID = id;
                model.Name = data.Name;
                model.Level = 2;
                model.Remark = data.Remark;
            }
            else if (level == 3)
            {
                var data = this.categoryBusiness.GetThirdCategory(id);
                model.ID = id;
                model.Name = data.Name;
                model.Level = 3;
                model.Remark = data.Remark;
            }
            else
            {
                return HttpNotFound();
            }

            return View(model);
        }

        /// <summary>
        /// 编辑分类
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(CategoryInfoModel model)
        {
            if (ModelState.IsValid)
            {
                ErrorCode result;

                if (model.Level == 1)
                {
                    var data = this.categoryBusiness.GetFirstCategory(model.ID);
                    data.Name = model.Name;
                    data.Remark = model.Remark;
                    result = this.categoryBusiness.EditFirstCategory(data);
                }
                else if (model.Level == 2)
                {
                    var data = this.categoryBusiness.GetSecondCategory(model.ID);
                    data.Name = model.Name;
                    data.Remark = model.Remark;
                    result = this.categoryBusiness.EditSecondCategory(data);
                }
                else
                {
                    var data = this.categoryBusiness.GetThirdCategory(model.ID);
                    data.Name = model.Name;
                    data.Remark = model.Remark;
                    result = this.categoryBusiness.EditThirdCategory(data);
                }


                if (result == ErrorCode.Success)
                {
                    TempData["Message"] = "编辑类别成功";
                    return RedirectToAction("Index", new { controller = "Category" });
                }
                else
                {
                    TempData["Message"] = "编辑类别失败";
                    ModelState.AddModelError("", "编辑类别失败: " + result.DisplayName());
                }
            }

            return View(model);
        }
        #endregion //Action

        #region JSON
        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <remarks>
        /// 调用:
        /// /Category/CreateThirdCategory
        /// </remarks>
        /// <returns></returns>
        public JsonResult GetFirstCategory()
        {
            var first = this.categoryBusiness.GetFirstCategory();
            var data = from r in first
                       select new { r.ID, r.Name };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取二级分类
        /// </summary>
        /// <param name="firstId">一级分类ID</param>
        /// <remarks>
        /// 调用：
        /// /Category/CreateThirdCategory
        /// /Cargo/Create
        /// </remarks>
        /// <returns></returns>
        public JsonResult GetSecondCategory(int firstId)
        {
            var second = this.categoryBusiness.GetSecondCategoryByFirst(firstId);
            var data = from r in second
                       select new { r.ID, r.Name };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 获取三级分类
        /// </summary>
        /// <param name="secondId">二级分类ID</param>
        /// <remarks>
        /// 调用：
        /// /Cargo/Create
        /// </remarks>
        /// <returns></returns>
        public JsonResult GetThirdCategory(int secondId)
        {
            var third = this.categoryBusiness.GetThirdCategoryBySecond(secondId);
            var data = from r in third
                       select new { r.ID, r.Name };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion //JSON
    }
}