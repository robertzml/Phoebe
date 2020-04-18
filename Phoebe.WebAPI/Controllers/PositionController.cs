using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.Entity;
    using Phoebe.Core.View;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 仓位控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        #region Query
        /// <summary>
        /// 仓位列表
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Position>> List(int shelfId, int? row)
        {
            PositionBusiness positionBusiness = new PositionBusiness();

            if (row.HasValue)
            {
                if (row.Value == 0)
                    return positionBusiness.FindByShelf(shelfId);
                else
                    return positionBusiness.FindList(shelfId, row.Value);
            }
            else
            {
                return positionBusiness.FindByShelf(shelfId);
            }
        }

        /// <summary>
        /// 仓位列表
        /// </summary>
        /// <param name="shelfId"></param>
        /// <param name="row"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<PositionView>> ListInLayer(int shelfId, int row, int layer)
        {
            PositionViewBusiness positionViewBusiness = new PositionViewBusiness();
            return positionViewBusiness.FindList(shelfId, row, layer);
        }

        /// <summary>
        /// 查找仓位
        /// </summary>
        /// <param name="shelfId"></param>
        /// <param name="row"></param>
        /// <param name="layer"></param>
        /// <param name="depth"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<PositionView> Find(int shelfId, int row, int layer, int depth)
        {
            PositionViewBusiness positionViewBusiness = new PositionViewBusiness();
            return positionViewBusiness.Single(r => r.ShelfId == shelfId && r.Row == row && r.Layer == layer && r.Depth == depth);
        }

        /// <summary>
        /// 查找仓位
        /// </summary>
        /// <param name="id">仓位ID</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<PositionView> Get(int id)
        {
            PositionViewBusiness positionViewBusiness = new PositionViewBusiness();
            return positionViewBusiness.FindById(id);
        }

        /// <summary>
        /// 仓位数量
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int> Count(int shelfId)
        {
            PositionBusiness positionBusiness = new PositionBusiness();
            return positionBusiness.Count(shelfId);
        }
        #endregion //Query

        #region Action
        /// <summary>
        /// 生成仓位
        /// </summary>
        /// <param name="shelfId"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Generate(int shelfId)
        {
            PositionBusiness positionBusiness = new PositionBusiness();

            var task = Task.Run(() =>
            {
                var result = positionBusiness.Generate(shelfId);

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
        /// 编辑
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(Position position)
        {
            PositionBusiness positionBusiness = new PositionBusiness();

            var task = Task.Run(() =>
            {
                var result = positionBusiness.Update(position);

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