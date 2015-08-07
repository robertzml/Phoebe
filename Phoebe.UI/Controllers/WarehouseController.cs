using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Model;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 仓库控制器
    /// </summary>
    public class WarehouseController : Controller
    {
        #region Field
        /// <summary>
        /// 仓库业务
        /// </summary>
        private WarehouseBusiness warehouseBusiness;
        #endregion //Field

        #region Constructor
        public WarehouseController()
        {
            this.warehouseBusiness = new WarehouseBusiness();
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 仓库主页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var data = this.warehouseBusiness.Get();
            return View(data);
        }

        /// <summary>
        /// 仓库信息
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult Info(int id)
        {
            var data = this.warehouseBusiness.Get(id);
            return View(data);
        }

        /// <summary>
        /// 编辑仓库
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var data = this.warehouseBusiness.Get(id);
            if (data == null)
                return HttpNotFound();

            return View(data);
        }
        #endregion //Action
    }
}