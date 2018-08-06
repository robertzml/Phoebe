using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.ClientDx
{
    using Poseidon.Base.Framework;
    using Poseidon.Base.System;
    using Poseidon.Common;
    using Phoebe.Core.BL;
    using Phoebe.Core.DL;

    public static class GlobalAction
    {
        #region Field
        public static LoginUser CurrentUser = null;
        #endregion //Field

        #region Method
        /// <summary>
        /// 全局初始化
        /// </summary>
        public static void Initialize()
        {
            try
            {
                // 设置连接字符串
                string source = AppConfig.GetAppSetting("ConnectionSource");
                if (string.IsNullOrEmpty(source))
                {
                    Logger.Instance.Error("连接源未确定");
                    throw new PoseidonException(ErrorCode.DatabaseConnectionNotFound);
                }

                string connection = "";

                if (source == "appconfig")
                {
                    connection = AppConfig.GetConnectionString();
                }

                if (string.IsNullOrEmpty(connection))
                {
                    Logger.Instance.Error("连接字符串未找到");
                    throw new PoseidonException(ErrorCode.DatabaseConnectionNotFound);
                }

                Cache.Instance.Add("ConnectionString", connection);
                Logger.Instance.Debug("连接字符串已设置");

                // 设置数据库类型
                string dalPrefix = AppConfig.GetAppSetting("DALPrefix");
                Cache.Instance.Add("DALPrefix", dalPrefix);
                Logger.Instance.Debug("数据库类型已设置");

                // 设置服务访问类型
                string callerType = AppConfig.GetAppSetting("CallerType");
                Cache.Instance.Add("CallerType", callerType);
                Logger.Instance.Debug("服务访问类型已设置");
            }
            catch (Exception e)
            {
                Logger.Instance.Exception("初始化失败", e);
                throw new PoseidonException(ErrorCode.Error);
            }
        }

        /// <summary>
        /// 设置登录用户
        /// </summary>
        /// <param name="user">用户信息</param>
        public static LoginUser ConvertToLoginUser(User user)
        {
            LoginUser lu = new LoginUser
            {
                Id = user.Id.ToString(),
                UserName = user.UserName,
                Name = user.Name,
                LastLoginTime = user.LastLoginTime,
                CurrentLoginTime = user.CurrentLoginTime,
                Remark = user.Remark,
                Status = user.Status
            };

            lu.IsRoot = BusinessFactory<UserBusiness>.Instance.IsRoot(user);

            return lu;
        }
        #endregion //Method
    }
}
