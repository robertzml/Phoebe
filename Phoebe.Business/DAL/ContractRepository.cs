using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 合同Repository
    /// </summary>
    public class ContractRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<Contract>
    {
        #region Method
        /// <summary>
        /// 根据ID查找合同
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        public Contract FindById(object id)
        {
            return this.context.Contracts.Find(id);
        }

        /// <summary>
        /// 查找所有合同
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Contract> FindAll()
        {
            return this.context.Contracts;
        }

        /// <summary>
        /// 根据条件查找合同
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<Contract> Find(Expression<Func<Contract, bool>> predicate)
        {
            return this.context.Contracts.Where(predicate);
        }

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="entity">合同对象</param>
        /// <returns></returns>
        public ErrorCode Create(Contract entity)
        {
            try
            {
                entity.Status = 0;

                if (this.context.Contracts.Any(r => r.Number == entity.Number))
                    return ErrorCode.DuplicateNumber;

                this.context.Contracts.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 编辑合同
        /// </summary>
        /// <param name="entity">合同实体</param>
        /// <returns></returns>
        public ErrorCode Update(Contract entity)
        {
            try
            {
                if (this.context.Contracts.Any(r => r.Id != entity.Id && r.Number == entity.Number))
                    return ErrorCode.DuplicateNumber;

                this.context.Entry(entity).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        public ErrorCode Delete(Contract entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode CreateRange(List<Contract> entities)
        {
            throw new NotImplementedException();
        }

        public Contract FindOne(Expression<Func<Contract, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
