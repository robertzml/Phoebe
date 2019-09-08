using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Base.System;
    using Phoebe.Core.BL;
    using Phoebe.Core.Utility;
    using Phoebe.Common;
    using Phoebe.WebAPI.Model;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 获取数据表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<string>> GetTables()
        {
            return DbUtility.GetTables();
        }

        /// <summary>
        /// 获取字段
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<string>> GetColumns(string tableName)
        {
            return DbUtility.GetColumns(tableName);
        }

        [HttpGet]
        public ActionResult<List<Dict>> GetEntityStatus()
        {
            List<Dict> dicts = new List<Dict>();

            foreach (EntityStatus status in Enum.GetValues(typeof(EntityStatus)))
            {
                Dict dict = new Dict();
                dict.Value = Convert.ToInt32(status);
                dict.Text = status.DisplayName();              

                dicts.Add(dict);
            }

            return dicts;
        }
        #endregion //Action
    }
}