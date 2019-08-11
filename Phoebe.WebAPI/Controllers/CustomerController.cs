using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phoebe.Core.BL;
using Phoebe.Core.Entity;

namespace Phoebe.WebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public ActionResult<List<Customer>> List()
        {
            CustomerBusiness customerBusiness = new CustomerBusiness();
            return customerBusiness.FindAll();
        }
    }
}