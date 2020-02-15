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
    using Phoebe.Core.DL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.Service;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 搬运入库控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarryInTaskController : ControllerBase
    {
        #region Query
        /// <summary>
        /// 获取搬运入库任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<CarryInTaskView> Get(string id)
        {
            CarryInTaskViewBusiness carryInTaskViewBusiness = new CarryInTaskViewBusiness();
            return carryInTaskViewBusiness.FindById(id);
        }

        /// <summary>
        /// 根据入库任务查找
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public ActionResult<List<CarryInTaskView>> FindByStockInTask(string taskId)
        {
            CarryInTaskViewBusiness carryInTaskViewBusiness = new CarryInTaskViewBusiness();
            return carryInTaskViewBusiness.FindByStockInTask(taskId);
        }

        /// <summary>
        /// 根据出库任务查找
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public ActionResult<List<CarryInTaskView>> FindByStockOutTask(string taskId)
        {
            CarryInTaskViewBusiness carryInTaskViewBusiness = new CarryInTaskViewBusiness();
            return carryInTaskViewBusiness.FindByStockOutTask(taskId);
        }

        /// <summary>
        /// 根据托盘码查找入库任务
        /// </summary>
        /// <param name="trayCode"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryInTaskView>> FindByTray(string trayCode)
        {
            CarryInTaskViewBusiness carryInTaskViewBusiness = new CarryInTaskViewBusiness();
            return carryInTaskViewBusiness.FindByTray(trayCode, EntityStatus.StockInCheck);
        }

        /// <summary>
        /// 查找用户当前接单任务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryInTaskView>> FindCurrentReceive(int userId)
        {
            CarryInTaskViewBusiness carryInTaskViewBusiness = new CarryInTaskViewBusiness();
            return carryInTaskViewBusiness.FindCurrentReceive(userId);
        }
        #endregion //Action

        #region Action
        /// <summary>
        /// 添加搬运入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActionResult<ResponseData>> Create(CarryInTask model)
        {
            StockInService stockInService = new StockInService();

            var task = Task.Run(() =>
            {
                var result = stockInService.AddCarryIn(model);

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
        /// 入库接单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> ReceiveTask(CarryInReceiveModel model)
        {
            CarryInTaskBusiness taskBusiness = new CarryInTaskBusiness();

            var task = Task.Run(() =>
            {
                ResponseData data = new ResponseData();

                var result = taskBusiness.Receive(model.TrayCode, model.UserId);

                data.Status = result.success ? 0 : 1;
                data.ErrorMessage = result.errorMessage;

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 入库上架
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> EnterTask(CarryInEnterModel model)
        {
            CarryInTaskBusiness taskBusiness = new CarryInTaskBusiness();

            var task = Task.Run(() =>
            {
                ResponseData data = new ResponseData();

                var result = taskBusiness.Enter(model.TrayCode, model.ShelfCode, model.UserId);

                data.Status = result.success ? 0 : 1;
                data.ErrorMessage = result.errorMessage;

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 入库确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> FinishTask(CarryInFinishModel model)
        {
            CarryInTaskBusiness taskBusiness = new CarryInTaskBusiness();

            var task = Task.Run(() =>
            {
                ResponseData data = new ResponseData();

                var result = taskBusiness.Finish(model.TaskId, model.UserId, model.TrayCode, model.MoveCount, model.MoveWeight, model.Remark);

                data.Status = result.success ? 0 : 1;
                data.ErrorMessage = result.errorMessage;

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 取消接单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> UnReceiveTask(CarryInReceiveModel model)
        {
            CarryInTaskBusiness taskBusiness = new CarryInTaskBusiness();

            var task = Task.Run(() =>
            {
                ResponseData data = new ResponseData();

                var result = taskBusiness.UnReceive(model.TrayCode, model.UserId);

                data.Status = result.success ? 0 : 1;
                data.ErrorMessage = result.errorMessage;

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 删除搬运入库任务
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Delete(string id)
        {
            StockInService stockInService = new StockInService();

            var task = Task.Run(() =>
            {
                var result = stockInService.DeleteCarryIn(id);

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