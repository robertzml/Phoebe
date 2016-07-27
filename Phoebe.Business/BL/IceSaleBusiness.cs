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
    /// 冰块销售业务类
    /// </summary>
    public class IceSaleBusiness : BaseBusiness<IceSale>
    {
        #region Field
        /// <summary>
        /// 数据访问接口
        /// </summary>
        private IBaseDataAccess<IceSale> dal;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 冰块销售业务类
        /// </summary>
        public IceSaleBusiness() : base()
        {
            this.dal = RepositoryFactory<IceSaleRepository>.Instance;
            base.Init(this.dal);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按时间段获取销售记录
        /// </summary>
        /// <param name="from">开始日期</param>
        /// <param name="to">结束日期</param>
        /// <returns></returns>
        public List<IceSale> Get(DateTime from, DateTime to)
        {
            var data = this.dal.Find(r => r.SaleTime >= from && r.SaleTime <= to).OrderByDescending(r => r.SaleTime);
            return data.ToList();
        }

        /// <summary>
        /// 添加销售
        /// </summary>
        /// <param name="entity">冰块销售对象</param>
        /// <returns></returns>
        public override ErrorCode Create(IceSale entity)
        {
            //check store count
            var store = BusinessFactory<IceStoreBusiness>.Instance.GetByType((IceType)entity.IceType);
            if (entity.SaleCount > store.Count)
                return ErrorCode.IceOutCountOverflow;
            if (entity.SaleWeight > store.Weight)
                return ErrorCode.IceOutWeightOverflow;

            return ErrorCode.NotImplement;

            //generate ice flow
            //IceFlow iceFlow = new IceFlow();
            //iceFlow.Id = Guid.NewGuid();
            //if (entity.IceType == (int)IceType.Complete)
            //    iceFlow.FlowType = (int)IceFlowType.CompleteSaleOut;
            //else
            //    iceFlow.FlowType = (int)IceFlowType.FragmentSaleOut;
            //iceFlow.IceType = entity.IceType;
            //iceFlow.FlowCount = entity.SaleCount;
            //iceFlow.FlowWeight = entity.SaleWeight;
            //iceFlow.FlowTime = entity.SaleTime;
            //iceFlow.UserId = entity.UserId;
            //iceFlow.CreateTime = entity.CreateTime;
            //iceFlow.Remark = entity.Remark;
            //iceFlow.Status = (int)EntityStatus.Normal;

            //entity.Id = Guid.NewGuid();
            //entity.FlowId = iceFlow.Id;
            //entity.Status = (int)EntityStatus.Normal;

            //var trans = new TransactionRepository();
            //var result = trans.IceSaleAddTrans(entity, iceFlow);

            //return result;
        }
        #endregion //Method
    }
}
