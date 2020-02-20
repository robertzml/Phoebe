using System;
using System.Collections.Generic;
using System.Text;

namespace Phoebe.Core.Service
{
    using SqlSugar;
    using Phoebe.Base.Framework;
    using Phoebe.Base.System;
    using Phoebe.Core.Entity;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;
    using Phoebe.Core.View;
    using Phoebe.Core.Utility;

    /// <summary>
    /// 搬运出库业务类
    /// </summary>
    public class CarryOutService : AbstractService
    {
        #region Carry Out Service
        /// <summary>
        /// 未指定下架
        /// </summary>
        /// <param name="trayCode">托盘码</param>
        /// <param name="shelfCode">货架码</param>
        /// <param name="userId">操作人ID</param>
        /// <returns></returns>
        /// <remarks>
        /// 叉车工自行扫码下架
        /// </remarks>
        public (bool success, string errorMessage, List<StoreView> stores) LeaveUnassign(string trayCode, string shelfCode, int userId)
        {
            var db = GetInstance();

            try
            {
                db.Ado.BeginTran();

                // 找出最外侧占用的仓位
                PositionBusiness positionBusiness = new PositionBusiness();
                var position = positionBusiness.FindOutside(shelfCode, db);
                if (position == null)
                {
                    return (false, "未找到可用托盘", null);
                }

                // 获取叉车工用户
                UserBusiness userBusiness = new UserBusiness();
                var user = userBusiness.FindById(userId, db);

                // 找出仓位对应库存
                CarryOutTaskBusiness carryOutTaskBusiness = new CarryOutTaskBusiness();
                StoreBusiness storeBusiness = new StoreBusiness();
                StoreViewBusiness storeViewBusiness = new StoreViewBusiness();
                var stores = storeViewBusiness.FindByPosition(position.Id, true, db);

                // 遍历该仓位上的库存记录
                foreach (var store in stores)
                {
                    if (store.TrayCode != trayCode)
                        return (false, "托盘码与当前在库托盘不一致", null);

                    // 由库存记录创建搬运出库任务
                    var result = carryOutTaskBusiness.Create(store, shelfCode, user, db);

                    // 库存记录下架
                    storeBusiness.Leave(store.Id, result.t.Id, db);
                }

                // 更新仓位状态
                positionBusiness.UpdateStatus(position, EntityStatus.Available, db);

                db.Ado.CommitTran();
                return (true, "", stores);
            }
            catch (Exception e)
            {
                db.Ado.RollbackTran();
                return (false, e.Message, null);
            }
        }
        #endregion //Carry Out Servie
    }
}
