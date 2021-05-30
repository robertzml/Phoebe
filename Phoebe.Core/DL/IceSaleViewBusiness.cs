using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Core.View;

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
        #endregion //Method
    }
}
