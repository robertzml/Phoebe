using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Phoebe.Business;
using Phoebe.Common;
using Phoebe.Model;

namespace Phoebe.UI.Controllers
{
    /// <summary>
    /// 合同控制器
    /// </summary>
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
            var data = this.contractBusiness.Get();
            return View(data);
        }
        #endregion //Action
    }
}