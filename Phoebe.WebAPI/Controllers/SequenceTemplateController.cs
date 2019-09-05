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
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 编号模板控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SequenceTemplateController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 编号模板列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<SequenceTemplate>> List()
        {
            SequenceTemplateBusiness sequenceBusiness = new SequenceTemplateBusiness();
            return sequenceBusiness.FindAll();
        }

        /// <summary>
        /// 编号模板信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<SequenceTemplate> Get(string id)
        {
            SequenceTemplateBusiness sequenceBusiness = new SequenceTemplateBusiness();
            return sequenceBusiness.FindById(id);
        }

        /// <summary>
        /// 添加编号模板
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(SequenceTemplate sequence)
        {
            SequenceTemplateBusiness sequenceBusiness = new SequenceTemplateBusiness();

            var task = Task.Run(() =>
            {
                sequence.Id = Guid.NewGuid().ToString();
                var result = sequenceBusiness.Create(sequence);

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