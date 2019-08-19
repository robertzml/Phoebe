using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 合同控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 合同列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Contract>> List()
        {
            ContractBusiness contractBusiness = new ContractBusiness();
            return contractBusiness.FindAll();
        }

        /// <summary>
        /// 合同信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Contract> Get(int id)
        {
            ContractBusiness contractBusiness = new ContractBusiness();
            return contractBusiness.FindById(id);
        }
        #endregion //Action
    }
}