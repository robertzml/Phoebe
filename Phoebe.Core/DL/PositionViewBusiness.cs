using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.DL
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;

    public class PositionViewBusiness : AbstractBusiness<PositionView, int>, IBaseBL<PositionView, int>
    {
        #region Method
        /// <summary>
        /// 查找仓位
        /// </summary>
        /// <param name="shelfId"></param>
        /// <param name="row"></param>
        /// <param name="layer"></param>
        /// <returns></returns>
        public List<PositionView> FindList(int shelfId, int row, int layer)
        {
            var db = GetInstance();
            return db.Queryable<PositionView>().Where(r => r.ShelfId == shelfId && r.Row == row && r.Layer == layer).OrderBy(r => r.Number).ToList();
        }
        #endregion //Method
    }
}