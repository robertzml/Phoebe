using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 普通库存控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NormalStoreController : ControllerBase
    {
        #region Query
        /// <summary>
        /// 库存信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<NormalStoreView> Get(string id)
        {
            NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();
            return normalStoreViewBusiness.FindById(id);
        }

        /// <summary>
        /// 按合同查找库存
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns></returns>
        [HttpGet]
        public List<NormalStoreView> FindByContract(int contractId)
        {
            NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();
            return normalStoreViewBusiness.FindByContract(contractId);
        }
        #endregion //Query
    }
}