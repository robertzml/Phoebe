using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 类别业务类
    /// </summary>
    public class CategoryBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public CategoryBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有一级分类
        /// </summary>
        /// <returns></returns>
        public List<FirstCategory> GetFirstCategory()
        {
            return this.context.FirstCategories.ToList();
        }

        /// <summary>
        /// 获取一级分类
        /// </summary>
        /// <param name="id">一级分类ID</param>
        /// <returns></returns>
        public FirstCategory GetFirstCategory(int id)
        {
            return this.context.FirstCategories.Find(id);
        }

        /// <summary>
        /// 获取所有二级分类
        /// </summary>
        /// <returns></returns>
        public List<SecondCategory> GetSecondCategory()
        {
            return this.context.SecondCategories.ToList();
        }

        /// <summary>
        /// 获取一级分类下二级分类
        /// </summary>
        /// <param name="firstId">一级分类ID</param>
        /// <returns></returns>
        public List<SecondCategory> GetSecondCategoryByFirst(int firstId)
        {
            return this.context.SecondCategories.Where(r => r.FirstCategoryID == firstId || r.ID == 0).ToList();
        }

        /// <summary>
        /// 获取二级分类
        /// </summary>
        /// <param name="id">二级分类ID</param>
        /// <returns></returns>
        public SecondCategory GetSecondCategory(int id)
        {
            return this.context.SecondCategories.Find(id);
        }

        /// <summary>
        /// 获取空二级分类
        /// </summary>
        /// <returns></returns>
        public List<SecondCategory> GetSecondEmpty()
        {
            return this.context.SecondCategories.Where(r => r.ID == 0).ToList();
        }

        /// <summary>
        /// 获取所有三级分类
        /// </summary>
        /// <returns></returns>
        public List<ThirdCategory> GetThirdCategory()
        {
            return this.context.ThirdCategories.ToList();
        }

        /// <summary>
        /// 获取二级分类下三级分离
        /// </summary>
        /// <param name="secondId">二级分类ID</param>
        /// <returns></returns>
        public List<ThirdCategory> GetThirdCategoryBySecond(int secondId)
        {
            return this.context.ThirdCategories.Where(r => r.SecondCategoryID == secondId || r.ID == 0).ToList();
        }

        /// <summary>
        /// 获取三级分类
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ThirdCategory GetThirdCategory(int id)
        {
            return this.context.ThirdCategories.Find(id);
        }

        /// <summary>
        /// 添加一级分类
        /// </summary>
        /// <param name="data">一级分类数据</param>
        /// <returns></returns>
        public ErrorCode CreateFirstCategory(FirstCategory data)
        {
            try
            {
                data.Status = 0;
                this.context.FirstCategories.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 添加二级分类
        /// </summary>
        /// <param name="data">二级分类数据</param>
        /// <returns></returns>
        public ErrorCode CreateSecondCategory(SecondCategory data)
        {
            try
            {
                data.Status = 0;
                this.context.SecondCategories.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 添加三级分类
        /// </summary>
        /// <param name="data">三级分类数据</param>
        /// <returns></returns>
        public ErrorCode CreateThirdCategory(ThirdCategory data)
        {
            try
            {
                data.Status = 0;
                this.context.ThirdCategories.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 编辑一级分类
        /// </summary>
        /// <param name="data">一级分类数据</param>
        /// <returns></returns>
        public ErrorCode EditFirstCategory(FirstCategory data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 编辑二级分类
        /// </summary>
        /// <param name="data">二级分类数据</param>
        /// <returns></returns>
        public ErrorCode EditSecondCategory(SecondCategory data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 编辑三级分类
        /// </summary>
        /// <param name="data">三级分类数据</param>
        /// <returns></returns>
        public ErrorCode EditThirdCategory(ThirdCategory data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Method
    }
}
