﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Base.System;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Service;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 出库控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StockOutController : ControllerBase
    {
        #region Common
        /// <summary>
        /// 获取月度分组
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string[] GetMonthGroup()
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            return stockOutViewBusiness.GetMonthGroup();
        }
        #endregion //Common

        #region Stock Out Query
        /// <summary>
        /// 获取出库列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockOutView>> List()
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            return stockOutViewBusiness.FindAll().OrderByDescending(r => r.FlowNumber).ToList();
        }

        /// <summary>
        /// 按月度获取出库列表
        /// </summary>
        /// <param name="monthTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockOutView>> ListByMonth(string monthTime)
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            return stockOutViewBusiness.FindByMonth(monthTime);
        }

        /// <summary>
        /// 获取出库列表
        /// </summary>
        /// <param name="outTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockOutView>> ListByTime(DateTime outTime)
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            return stockOutViewBusiness.FindByTime(outTime);
        }


        /// <summary>
        /// 获取未完成出库单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockOutView>> ListUnfinish()
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            return stockOutViewBusiness.FindUnfinish();
        }


        /// <summary>
        /// 获取出库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<StockOutView> Get(string id)
        {
            StockOutViewBusiness stockOutViewBusiness = new StockOutViewBusiness();
            return stockOutViewBusiness.FindById(id);
        }
        #endregion //Stock Out Query

        #region Stock Out Action
        /// <summary>
        /// 添加出库
        /// </summary>
        /// <param name="stockOut"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(StockOut stockOut)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.AddReceipt(stockOut);

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
        /// 编辑出库
        /// </summary>
        /// <param name="stockIn"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(StockOut stockOut)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.UpdateReceipt(stockOut);

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
        /// 确认出库
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Confirm(string id)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.FinishReceipt(id);

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
        /// 删除出库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Delete(string id)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.DeleteReceipt(id);

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
        /// 撤回出库单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Revert(string id)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.RevertReceipt(id);

                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }
        #endregion //Stock Out Action

        #region Billing Query
        /// <summary>
        /// 获取入库计费
        /// </summary>
        /// <param name="stockInId">入库单ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<OutBillingView>> GetBillings(string stockOutId)
        {
            OutBillingViewBusiness outBillingViewBusiness = new OutBillingViewBusiness();
            return outBillingViewBusiness.FindByStockOut(stockOutId);
        }
        #endregion //Billing Query

        #region Billing Action
        /// <summary>
        /// 设置出库费用
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> SetBilling(List<OutBilling> entity)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.SetBilling(entity);

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
        /// 设置冷藏费差价
        /// </summary>
        /// <param name="stockOutId">出库单ID</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> SetDiffCold(string stockOutId)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.SetDiffColdFee(stockOutId);

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

        #region Stock Out Task Query
        /// <summary>
        /// 获取出库任务列表
        /// </summary>
        /// <param name="stockOutId">出库单ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockOutTaskView>> TaskList(string stockOutId)
        {
            StockOutTaskViewBusiness taskViewBusiness = new StockOutTaskViewBusiness();
            return taskViewBusiness.Query(r => r.StockOutId == stockOutId);
        }

        /// <summary>
        /// 获取出库任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<StockOutTaskView> GetTask(string taskId)
        {
            StockOutTaskViewBusiness taskViewBusiness = new StockOutTaskViewBusiness();
            return taskViewBusiness.FindById(taskId);
        }

        /// <summary>
        /// 按日期获取出库任务
        /// </summary>
        /// <param name="date"></param>
        /// <param name="contractId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<StockOutTaskView>> FindTaskByDate(DateTime date, int contractId)
        {
            StockOutTaskViewBusiness taskViewBusiness = new StockOutTaskViewBusiness();
            return taskViewBusiness.FindByDate(contractId, date);
        }
        #endregion //Stock Out Task Query

        #region Stock Out Task Action
        /// <summary>
        /// 添加普通出库任务
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> AddNormalOut(StockOutAddNormalModel model)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.AddNormalOut(model.StockOutId, model.Tasks, model.UserId);

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
        /// 添加仓位出库任务
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> AddPositionOut(StockOutAddPositionModel model)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.AddPositionStore(model.StockOutId, model.Tasks, model.UserId);

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
        /// 编辑普通库出库任务
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> EditTask(StockOutTask model)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.EditTask(model);

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
        /// 完成出库任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> FinishTask(string taskId)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.FinishTask(taskId);
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
        /// 删除出库任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> DeleteTask(string taskId)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.DeleteTask(taskId);
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
        /// 提交出库
        /// </summary>
        /// <param name="data">搬运出库任务</param>
        /// <returns></returns>
        public async Task<ActionResult<ResponseData>> ScanCarryOut(StockOutTaskAddCarryOutModel model)
        {
            StockOutService stockOutService = new StockOutService();

            var task = Task.Run(() =>
            {
                var result = stockOutService.ScanCarryOut(model.StockOutId, model.TrayCode, model.UserId, model.Tasks);
                ResponseData data = new ResponseData
                {
                    Status = result.success ? 0 : 1,
                    ErrorMessage = result.errorMessage
                };

                return data;
            });

            return await task;
        }
        #endregion //Stock Out Task Action
    }
}