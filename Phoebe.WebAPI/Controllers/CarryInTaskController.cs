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
        /// 获取所有搬运出库任务
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryInTaskView>> List()
        {
            CarryInTaskViewBusiness carryInTaskViewBusiness = new CarryInTaskViewBusiness();
            return carryInTaskViewBusiness.FindAll();
        }

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
        /// 查找已清点的入库任务
        /// </summary>
        /// <param name="trayCode"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryInTaskView>> FindInCheck(string trayCode)
        {
            CarryInTaskViewBusiness carryInTaskViewBusiness = new CarryInTaskViewBusiness();
            return carryInTaskViewBusiness.Query(r => r.TrayCode == trayCode && r.Status == (int)EntityStatus.StockInCheck);
        }

        /// <summary>
        /// 根据托盘码查找进行中的搬运任务
        /// </summary>
        /// <param name="trayCode"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryInTaskView>> FindWorking(string trayCode)
        {
            CarryInTaskViewBusiness carryInTaskViewBusiness = new CarryInTaskViewBusiness();
            return carryInTaskViewBusiness.Query(r => r.TrayCode == trayCode && r.Status != (int)EntityStatus.StockInFinish);
        }

        /// <summary>
        /// 根据库存入库时间查找
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="inTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryInTaskView>> FindByInTime(int contractId, DateTime inTime)
        {
            CarryInTaskViewBusiness carryInTaskViewBusiness = new CarryInTaskViewBusiness();
            return carryInTaskViewBusiness.FindByInTime(contractId, inTime);
        }

        /// <summary>
        /// 根据库存出库时间查找
        /// </summary>
        /// <param name="contractId"></param>
        /// <param name="outTime"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<CarryInTaskView>> FindByOutTime(int contractId, DateTime outTime)
        {
            CarryInTaskViewBusiness carryInTaskViewBusiness = new CarryInTaskViewBusiness();
            return carryInTaskViewBusiness.FindByOutTime(contractId, outTime);
        }
        #endregion //Action

        #region Action
        /// <summary>
        /// 添加搬运入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(CarryInTask model)
        {
            CarryInService carryInService = new CarryInService();

            var task = Task.Run(() =>
            {
                var result = carryInService.AddTask(model);

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
        /// 入库上架
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> EnterTask(CarryInEnterModel model)
        {
            CarryInService carryInService = new CarryInService();

            var task = Task.Run(() =>
            {
                ResponseData data = new ResponseData();

                var result = carryInService.Enter(model.TrayCode, model.ShelfCode, model.UserId);

                data.Status = result.success ? 0 : 1;
                data.ErrorMessage = result.errorMessage;
                data.Entity = result.position;

                return data;
            });

            return await task;
        }

        /// <summary>
        /// 编辑搬运入库
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> EditTask(CarryInTask model)
        {
            CarryInService carryInService = new CarryInService();

            var task = Task.Run(() =>
            {
                ResponseData data = new ResponseData();

                var result = carryInService.EditTask(model);

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
            CarryInService carryInService = new CarryInService();

            var task = Task.Run(() =>
            {
                var result = carryInService.DeleteTask(id);

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