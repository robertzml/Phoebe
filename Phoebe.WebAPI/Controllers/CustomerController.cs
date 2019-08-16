using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.WebAPI.Model;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 客户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult<List<Customer>> List()
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();
            return customerBusiness.FindAll();
        }

        /// <summary>
        /// 客户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult<Customer> Get(int id)
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();
            return customerBusiness.FindById(id);
        }

        /// <summary>
        /// 编辑客户
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(Customer customer)
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();

            var task = Task.Run(() =>
            {
                var result = customerBusiness.Update(customer);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }
        #endregion //Action
    }
}