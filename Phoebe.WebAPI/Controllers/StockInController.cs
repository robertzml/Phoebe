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
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 入库控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockInController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 获取月度分组
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string[] GetMonthGroup()
        {
            StockInViewBusiness stockInViewBusiness = new StockInViewBusiness();
            return stockInViewBusiness.GetMonthGroup();
        }

        /// <summary>
        /// 获取入库列表
        /// </summary>
        /// <param name="monthTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockInView>> List(string monthTime)
        {
            StockInViewBusiness stockInViewBusiness = new StockInViewBusiness();
            if (string.IsNullOrEmpty(monthTime))
            {
                return stockInViewBusiness.FindAll();
            }
            else
            {
                return stockInViewBusiness.FindByMonth(monthTime);
            }
        }

        /// <summary>
        /// 获取入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<StockInView> Get(string id)
        {
            StockInViewBusiness stockInViewBusiness = new StockInViewBusiness();
            return stockInViewBusiness.FindById(id);
        }

        /// <summary>
        /// 添加入库
        /// </summary>
        /// <param name="stockIn"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(StockIn stockIn)
        {
            StockInBusiness stockInBusiness = new StockInBusiness();

            var task = Task.Run(() =>
            {
                var result = stockInBusiness.Create(stockIn);

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
        /// 获取入库任务列表
        /// </summary>
        /// <param name="stockInId">入库单ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockInTask>> TaskList(string stockInId)
        {
            StockInTaskBusiness taskBusiness = new StockInTaskBusiness();

            return taskBusiness.FindList(stockInId);
        }

        /// <summary>
        /// 添加入库任务
        /// </summary>
        /// <param name="inTask"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> AddTask(StockInTask inTask)
        {
            StockInTaskBusiness taskBusiness = new StockInTaskBusiness();

            var task = Task.Run(() =>
            {
                var result = taskBusiness.Create(inTask);

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
        #endregion //Action
    }
}