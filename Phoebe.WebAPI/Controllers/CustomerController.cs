using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Action
        public ActionResult<List<Customer>> List()
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();
            return customerBusiness.FindAll();
        }

        public ActionResult<Customer> Get(int id)
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();
            return customerBusiness.FindById(id);
        }
        #endregion //Action
    }
}