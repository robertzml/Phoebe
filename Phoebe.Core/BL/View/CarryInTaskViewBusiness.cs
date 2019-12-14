using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.BL
{
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.View;

    public class CarryInTaskViewBusiness : AbstractBusiness<CarryInTaskView, string>, IBaseBL<CarryInTaskView, string>
    {
        #region Method
        /// <summary>
        /// 根据托盘码查找任务
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public List<CarryInTaskView> FindByTray(string trayCode, EntityStatus status)
        {
            var db = GetInstance();

            var data = db.Queryable<CarryInTaskView>().Where(r => r.TrayCode == trayCode && r.Status == (int)status);

            return data.ToList();           
        }
        #endregion //Method
    }
}
