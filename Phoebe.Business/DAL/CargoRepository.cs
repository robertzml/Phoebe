using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 货品Repository
    /// </summary>
    public class CargoRepository : SqlDataAccess<PhoebeContext>, IBaseDataAccess<Cargo>
    {
        #region Method
        public Cargo FindById(object id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cargo> FindAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 按条件查找货品
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns></returns>
        public IEnumerable<Cargo> Find(Expression<Func<Cargo, bool>> predicate)
        {
            return this.context.Cargoes.Where(predicate);
        }

        /// <summary>
        /// 添加货品
        /// </summary>
        /// <param name="entity">货品实体</param>
        /// <returns></returns>
        public ErrorCode Create(Cargo entity)
        {
            try
            {
                if (this.context.Cargoes.Any(r => r.ContractId == entity.ContractId && r.CategoryId == entity.CategoryId &&
                    r.GroupType == entity.GroupType && r.UnitWeight == entity.UnitWeight && r.UnitVolume == entity.UnitVolume))
                    return ErrorCode.CargoExist;

                this.context.Cargoes.Add(entity);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        public ErrorCode CreateRange(List<Cargo> entities)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Update(Cargo entity)
        {
            throw new NotImplementedException();
        }

        public ErrorCode Delete(Cargo entity)
        {
            throw new NotImplementedException();
        }
        #endregion //Method
    }
}
