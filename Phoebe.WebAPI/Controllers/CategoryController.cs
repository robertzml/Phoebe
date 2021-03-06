﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Phoebe.WebAPI.Controllers
{
    using Phoebe.Core.BL;
    using Phoebe.Core.Entity;
    using Phoebe.WebAPI.Model;

    /// <summary>
    /// 分类控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Query
        /// <summary>
        /// 获取所有分类
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Category>> List()
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            return categoryBusiness.FindAll();
        }

        [HttpGet]
        public ActionResult<List<Category>> GetFirstCategory()
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            return categoryBusiness.GetFirstCategory();
        }

        [HttpGet]
        public ActionResult<List<Category>> GetChildren(int parentId)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            return categoryBusiness.GetChildCategory(parentId);
        }

        /// <summary>
        /// 获取分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<Category> Get(int id)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();
            return categoryBusiness.FindById(id);
        }
        #endregion //Query

        #region Action
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Create(Category category)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();

            var task = Task.Run(() =>
            {
                var result = categoryBusiness.Create(category);

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
        /// 编辑分类
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Update(Category category)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();

            var task = Task.Run(() =>
            {
                var result = categoryBusiness.Update(category);

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
        /// 删除分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ResponseData>> Delete(int id)
        {
            CategoryBusiness categoryBusiness = new CategoryBusiness();

            var task = Task.Run(() =>
            {
                var result = categoryBusiness.Delete(id);

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
