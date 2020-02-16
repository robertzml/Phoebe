using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Base.System;
    using Phoebe.Core.Service;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
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

        #region Stock In Query
        /// <summary>
        /// 获取入库列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockInView>> List()
        {
            StockInViewBusiness stockInViewBusiness = new StockInViewBusiness();
            return stockInViewBusiness.FindAll().OrderByDescending(r => r.FlowNumber).ToList();
        }

        /// <summary>
        /// 按月度获取入库列表
        /// </summary>
        /// <param name="monthTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockInView>> ListByMonth(string monthTime)
        {
            StockInViewBusiness stockInViewBusiness = new StockInViewBusiness();
            return stockInViewBusiness.FindByMonth(monthTime);
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
        /// 获取未完成入库单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockInView>> ListUnfinish()
        {
            StockInViewBusiness stockInViewBusiness = new StockInViewBusiness();
            return stockInViewBusiness.FindUnfinish();
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
        #endregion //Stock In Query

        #region Stock In Action
        /// <summary>
        /// 添加入库
        /// </summary>
        /// <param name="stockIn"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(StockIn stockIn)
        {
            StockInService stockInService = new StockInService();

            var task = Task.Run(() =>
            {
                var result = stockInService.AddReceipt(stockIn);

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
        /// 编辑入库
        /// </summary>
        /// <param name="stockIn"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(StockIn stockIn)
        {
            StockInService stockInService = new StockInService();

            var task = Task.Run(() =>
            {
                var result = stockInService.UpdateReceipt(stockIn);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage,
                    Entity = null
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
            StockInService stockInService = new StockInService();

            var task = Task.Run(() =>
            {
                var result = stockInService.ConfirmReceipt(id);

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
        /// 撤回入库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Revert(string id)
        {
            StockInBusiness stockInBusiness = new StockInBusiness();

            var task = Task.Run(() =>
            {
                var result = stockInBusiness.Revert(id);

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
        /// 删除入库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Delete(string id)
        {
            StockInService stockInService = new StockInService();

            var task = Task.Run(() =>
            {
                var result = stockInService.DeleteReceipt(id);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }
        #endregion //Stock In Action

        #region Billing Query
        /// <summary>
        /// 获取入库计费
        /// </summary>
        /// <param name="stockInId">入库单ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<InBillingView>> GetBillings(string stockInId)
        {
            InBillingViewBusiness inBillingViewBusiness = new InBillingViewBusiness();
            return inBillingViewBusiness.FindByStockIn(stockInId);
        }
        #endregion //Billing Query

        #region Billing Action
        /// <summary>
        /// 设置入库费用
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> SetBilling(List<InBilling> entity)
        {
            StockInService stockInService = new StockInService();

            var task = Task.Run(() =>
            {
                var result = stockInService.SetBilling(entity);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }
        #endregion //Billing Action

        #region Stock In Task Query
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
        #endregion //Stock In Task Query

        #region Stock In Task Action
        /// <summary>
        /// 添加入库任务
        /// </summary>
        /// <param name="inTask"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> AddTask(StockInTask inTask)
        {
            StockInService stockInService = new StockInService();

            var task = Task.Run(() =>
            {
                var result = stockInService.AddTask(inTask); //清点

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
        public async Task<ActionResult<ResponseData>> UpdateTask(StockInTask inTask)
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
            StockInService stockInService = new StockInService();

            var task = Task.Run(() =>
            {
                var result = stockInService.FinishTask(taskId);
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
        /// 删除入库任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> DeleteTask(string taskId)
        {
            StockInTaskBusiness taskBusiness = new StockInTaskBusiness();

            var task = Task.Run(() =>
            {
                var result = taskBusiness.Delete(taskId);
                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }
        #endregion //Stock In Task Action
    }
}