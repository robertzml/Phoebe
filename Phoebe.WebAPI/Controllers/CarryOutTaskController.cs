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
        /// 获取出库任务
        /// </summary>
        /// <returns></returns>
        public ActionResult<List<CarryOutTaskView>> ListToDo()
        {
            CarryOutTaskViewBusiness carryOutTaskViewBusiness = new CarryOutTaskViewBusiness();
            return carryOutTaskViewBusiness.ListToDo();
        }
        #endregion //Action
    }
}