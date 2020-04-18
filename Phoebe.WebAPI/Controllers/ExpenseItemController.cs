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
    /// 费用项目控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ExpenseItemController : ControllerBase
    {
        #region Query
        /// <summary>
        /// 费用项目列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<ExpenseItem>> List()
        {
            ExpenseItemBusiness expenseItemBusiness = new ExpenseItemBusiness();
            return expenseItemBusiness.FindAll().OrderBy(r => r.Code).ToList();
        }

        /// <summary>
        /// 费用项目信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ExpenseItem> Get(int id)
        {
            ExpenseItemBusiness expenseItemBusiness = new ExpenseItemBusiness();
            return expenseItemBusiness.FindById(id);
        }
        #endregion //Query

        #region Action
        /// <summary>
        /// 添加费用项目
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(ExpenseItem entity)
        {
            ExpenseItemBusiness expenseItemBusiness = new ExpenseItemBusiness();

            var task = Task.Run(() =>
            {
                var result = expenseItemBusiness.Create(entity);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage,
                    Entity = result.t
                };

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 编辑合同
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(ExpenseItem entity)
        {
            ExpenseItemBusiness expenseItemBusiness = new ExpenseItemBusiness();

            var task = Task.Run(() =>
            {
                var result = expenseItemBusiness.Update(entity);

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