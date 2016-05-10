using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    public class StockInDetailsRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<StockInDetail>
    {

        public StockInDetail FindById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockInDetail> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockInDetail> Find(Expression<Func<StockInDetail, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 添加入库记录
        /// </summary>
        /// <param name="entity">入库记录</param>
        /// <returns></returns>
        public ErrorCode Create(StockInDetail entity)
        {
            try
            {
                this.context.StockInDetails.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 添加多个入库详细记录
        /// </summary>
        /// <param name="entities">入库记录列表</param>
        /// <returns></returns>
        public ErrorCode CreateRange(List<StockInDetail> entities)
        {
            try
            {
                this.context.StockInDetails.AddRange(entities);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }


        public ErrorCode Update(StockInDetail entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(StockInDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
