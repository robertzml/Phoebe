using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Phoebe.Business
{
    using Phoebe.Base;
    using Phoebe.Model;
    using Phoebe.Business.DAL;

    /// <summary>
    /// 货品业务类
    /// </summary>
    public class CargoBusiness : BaseBusiness<Cargo>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<Cargo> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 货品业务类
        /// </summary>
        public CargoBusiness() : base()
        {
            this.dal = new CargoRepository();
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 由入库记录生成货品
        /// </summary>
        /// <param name="model">入库记录</param>
        /// <returns></returns>
        public Cargo Create(StockInModel model)
        {
            Cargo cargo = new Cargo();
            cargo.Id = Guid.NewGuid();
            cargo.ContractId = model.ContractId;
            cargo.CategoryId = model.CategoryId;
            cargo.GroupType = model.GroupType;
            cargo.UnitWeight = model.UnitWeight;
            cargo.UnitVolume = model.UnitVolume;
            cargo.RegisterTime = DateTime.Now;
            cargo.Status = 0;

            Expression<Func<Cargo, bool>> predicate = r => r.ContractId == cargo.ContractId && r.CategoryId == cargo.CategoryId &&
                r.GroupType == cargo.GroupType && r.UnitWeight == cargo.UnitWeight && r.UnitVolume == cargo.UnitVolume;
            var exist = this.dal.Find(predicate);
            if (exist.Count() == 0)
            {
                ErrorCode result= this.dal.Create(cargo);
                if (result == ErrorCode.Success)
                    return cargo;
                else
                    return null;
            }
            else
            {
                return exist.First();
            }
        }
        #endregion //Method
    }
}
