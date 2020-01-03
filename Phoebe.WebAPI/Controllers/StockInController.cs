using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Base.System;
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
        #region Common
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
        #endregion //Common

        #region Stock In
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
        /// 获取入库列表
        /// </summary>
        /// <param name="inTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockInView>> ListByTime(DateTime inTime)
        {
            StockInViewBusiness stockInViewBusiness = new StockInViewBusiness();
            return stockInViewBusiness.FindByTime(inTime);
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
        /// 确认入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Confirm(string id)
        {
            StockInBusiness stockInBusiness = new StockInBusiness();

            var task = Task.Run(() =>
            {
                var result = stockInBusiness.Confirm(id);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }
        #endregion //Stock In

        #region Stock In Task
        /// <summary>
        /// 获取入库任务列表
        /// </summary>
        /// <param name="stockInId">入库单ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockInTaskView>> TaskList(string stockInId)
        {
            StockInTaskViewBusiness taskViewBusiness = new StockInTaskViewBusiness();
            return taskViewBusiness.FindList(stockInId);
        }

        /// <summary>
        /// 获取入库任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<StockInTaskView> GetTask(string taskId)
        {
            StockInTaskViewBusiness taskViewBusiness = new StockInTaskViewBusiness();
            return taskViewBusiness.FindById(taskId);
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
                var result = taskBusiness.Create(inTask); //清点

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
        /// 编辑入库任务
        /// </summary>
        /// <param name="inTask"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> EditTask(StockInTask inTask)
        {
            StockInTaskBusiness taskBusiness = new StockInTaskBusiness();

            var task = Task.Run(() =>
            {
                var result = taskBusiness.Update(inTask);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 完成入库任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> FinishTask(string taskId)
        {
            StockInTaskBusiness taskBusiness = new StockInTaskBusiness();

            var task = Task.Run(() =>
            {
                var result = taskBusiness.Confirm(taskId);
                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }
        #endregion //Stock In Task
    }
}