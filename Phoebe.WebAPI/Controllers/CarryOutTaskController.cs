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
    using Phoebe.Core.Service;
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
        #region Query
        /// <summary>
        /// 获取所有搬运出库任务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryOutTaskView>> List()
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.FindAll();
        }

        /// <summary>
        /// 根据ID获取搬运出库任务
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<CarryOutTaskView> Get(string id)
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.FindById(id);
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
        /// 根据入库任务查找
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public ActionResult<List<CarryOutTaskView>> FindByStockInTask(string taskId)
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.FindByStockInTask(taskId);
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
        /// 根据托盘码获取当前搬运出库任务
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryOutTaskView>> FindByTray(string trayCode)
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.FindByTray(trayCode);
        }

        /// <summary>
        /// 根据库存入库时间查找
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="inTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryOutTaskView>> FindByInTime(int contractId, DateTime inTime)
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.FindByInTime(contractId, inTime);
        }

        /// <summary>
        /// 根据库存出库时间查找
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="outTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryOutTaskView>> FindByOutTime(int contractId, DateTime outTime)
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.FindByOutTime(contractId, outTime);
        }
        #endregion //Query

        #region Action
        /// <summary>
        /// 提交出库
        /// </summary>
        /// <param name="tasks"></param>
        /// <returns></returns>
        public async Task<ActionResult<ResponseData>> Create(List<CarryOutTask> tasks)
        {
            CarryOutService carryOutService = new CarryOutService();

            var task = Task.Run(() =>
            {
                var result = carryOutService.AddTasks(tasks);

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
        /// 出库下架-叉车工直接下架
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActionResult<ResponseData>> LeaveTask(CarryOutLeaveModel model)
        {
            CarryOutService carryOutService = new CarryOutService();

            var task = Task.Run(() =>
            {
                ResponseData data = new ResponseData();

                var result = carryOutService.Leave(model.TrayCode, model.ShelfCode, model.UserId);

                data.Status = result.success ? 0 : 1;
                data.ErrorMessage = result.errorMessage;
                data.Entity = result.stores;

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 搬运出库确认
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> FinishTask(CarryOutFinishModel model)
        {
            CarryOutService carryOutService = new CarryOutService();

            var task = Task.Run(() =>
            {
                ResponseData data = new ResponseData();

                var result = carryOutService.Finish(model.TaskId, model.UserId);

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
            CarryOutService carryOutService = new CarryOutService();

            var task = Task.Run(() =>
            {
                var result = carryOutService.DeleteTask(id);

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