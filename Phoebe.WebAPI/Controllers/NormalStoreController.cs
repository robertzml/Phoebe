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

        /// <summary>
        /// 出库时查找库存记录
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="cargoId">货品ID</param>
        /// <returns></returns>
        [HttpGet]
        public List<NormalStoreView> FindForStockOut(int contractId, string cargoId)
        {
            NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();
            return normalStoreViewBusiness.FindForStockOut(contractId, cargoId);
        }
        #endregion //Query

        #region Storage
        /// <summary>
        /// 获取库存记录链表
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<NormalStoreView> GetInOrder(string id)
        {
            NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();
            return normalStoreViewBusiness.GetInOrder(id);
        }

        /// <summary>
        /// 获取指定日库存
        /// </summary>
        /// <param name="contractId">合同ID</param>
        /// <param name="date">日期</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<NormalStoreView>> GetInDay(int contractId, DateTime date)
        {
            NormalStoreViewBusiness normalStoreViewBusiness = new NormalStoreViewBusiness();
            return normalStoreViewBusiness.GetInDay(contractId, date);
        }
        #endregion //Storage
    }
}