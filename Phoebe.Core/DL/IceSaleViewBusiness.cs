using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Core.BL;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 冰块销售视图业务类
    /// </summary>
    public class IceSaleViewBusiness : AbstractBusiness<IceSaleView, string>, IBaseBL<IceSaleView, string>
    {
        #region Method
        /// <summary>
        /// 按年度搜索入库记录
        /// </summary>
        /// <param name="year">入库年份</param>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<IceSaleView> FindByYear(int year, SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<IceSaleView>().Where(r => r.SaleTime.Year == year);
            return data.ToList();
        }

        /// <summary>
        /// 获取整冰销售总数量
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public int GetCompleteSaleCount(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<IceSaleView>().Where(r => r.IceType == (int)IceType.Complete).Sum(r => r.SaleCount);
            return data;
        }

        /// <summary>
        /// 获取碎冰销售总数量
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public int GetFragmentSaleCount(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            var data = db.Queryable<IceSaleView>().Where(r => r.IceType == (int)IceType.Fragment).Sum(r => r.SaleCount);
            return data;
        }

        /// <summary>
        /// 获取整冰在库数量
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public int GetCompleteStoreCount(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            IceStockBusiness iceStockBusiness = new IceStockBusiness();
            var inCount = iceStockBusiness.GetCompleteInCount(db);
            var outCount = iceStockBusiness.GetCompleteOutCount(db);
            var saleCount = GetCompleteSaleCount(db);

            return inCount - outCount - saleCount;
        }

        /// <summary>
        /// 获取碎冰在库数量
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public int GetFragmentStoreCount(SqlSugarClient db = null)
        {
            if (db == null)
                db = GetInstance();

            IceStockBusiness iceStockBusiness = new IceStockBusiness();

            var inCount = iceStockBusiness.GetFragmentInCount(db);
            var saleCount = GetFragmentSaleCount(db);

            return inCount - saleCount;
        }
        #endregion //Method
    }
}
