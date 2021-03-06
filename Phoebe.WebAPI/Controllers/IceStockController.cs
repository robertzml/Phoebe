﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 冰块入库控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IceStockController : ControllerBase
    {
        #region Query
        /// <summary>
        /// 冰块入库列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<IceStock>> List(int year)
        {
            IceStockBusiness iceStockBusiness = new IceStockBusiness();
            return iceStockBusiness.FindByYear(year);
        }

        /// <summary>
        /// 冰块入库信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IceStock> Get(string id)
        {
            IceStockBusiness iceStockBusiness = new IceStockBusiness();
            return iceStockBusiness.FindById(id);
        }

        /// <summary>
        /// 获取整冰入库数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<int> GetCompleteIn()
        {
            IceStockBusiness iceStockBusiness = new IceStockBusiness();
            return iceStockBusiness.GetCompleteInCount();
        }

        [HttpGet]
        public ActionResult<int> GetCompleteOut()
        {
            IceStockBusiness iceStockBusiness = new IceStockBusiness();
            return iceStockBusiness.GetCompleteOutCount();
        }

        [HttpGet]
        public ActionResult<int> GetFragmentIn()
        {
            IceStockBusiness iceStockBusiness = new IceStockBusiness();
            return iceStockBusiness.GetFragmentInCount();
        }
        #endregion //Query

        #region Action
        /// <summary>
        /// 冰块入库
        /// </summary>
        /// <param name="iceStock"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> StockIn(IceStock iceStock)
        {
            IceStockBusiness iceStockBusiness = new IceStockBusiness();

            var task = Task.Run(() =>
            {
                var result = iceStockBusiness.StockIn(iceStock);

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
        /// 冰块出库
        /// </summary>
        /// <param name="iceStock"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> StockOut(IceStock iceStock)
        {
            IceStockBusiness iceStockBusiness = new IceStockBusiness();

            var task = Task.Run(() =>
            {
                var result = iceStockBusiness.StockOut(iceStock);

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
        /// 删除入库记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Delete(string id)
        {
            IceStockBusiness iceStockBusiness = new IceStockBusiness();
            var task = Task.Run(() =>
            {
                var result = iceStockBusiness.Delete(id);

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
