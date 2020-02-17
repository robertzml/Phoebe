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
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 搬运出库控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarryOutTaskController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 提交出库
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public async Task<ActionResult<ResponseData>> Create(List<CarryOutTask> tasks)
        {
            CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();

            var task = Task.Run(() =>
            {
                var result = carryOutTaskBusiness.Create(tasks);

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
        /// 根据出库任务查找
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public ActionResult<List<CarryOutTaskView>> FindByStockOutTask(string taskId)
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.FindByStockOutTask(taskId);
        }

        /// <summary>
        /// 获取出库任务仓位码
        /// </summary>
        /// <returns></returns>
        public ActionResult<List<string>> ListToOut()
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.ListToOut();
        }

        /// <summary>
        /// 获取待办出库搬运任务
        /// </summary>
        /// <param name="positionNumber">仓位码</param>
        /// <returns></returns>
        public ActionResult<List<CarryOutTaskView>> FindByPosition(string positionNumber)
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.FindByPosition(positionNumber);
        }

        /// <summary>
        /// 查找用户当前接单任务
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryOutTaskView>> FindCurrentReceive(int userId)
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.FindCurrentReceive(userId);
        }

        /// <summary>
        /// 出库接单
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> ReceiveTask(CarryOutReceiveModel model)
        {
            CarryOutTaskBusiness taskBusiness = new CarryOutTaskBusiness();

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
        /// 出库下架
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> LeaveTask(CarryOutLeaveModel model)
        {
            CarryOutTaskBusiness taskBusiness = new CarryOutTaskBusiness();

            var task = Task.Run(() =>
            {
                ResponseData data = new ResponseData();

                var result = taskBusiness.Leave(model.TrayCode, model.ShelfCode, model.UserId);

                data.Status = result.success ? 0 : 1;
                data.ErrorMessage = result.errorMessage;

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 出库确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> FinishTask(CarryOutFinishModel model)
        {
            CarryOutTaskBusiness taskBusiness = new CarryOutTaskBusiness();

            var task = Task.Run(() =>
            {
                ResponseData data = new ResponseData();

                var result = taskBusiness.Finish(model.TaskId, model.UserId, model.MoveCount, model.MoveWeight, model.Remark);

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
            CarryOutTaskBusiness taskBusiness = new CarryOutTaskBusiness();

            var task = Task.Run(() =>
            {
                var result = taskBusiness.Delete(id);

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