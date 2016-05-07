using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Phoebe.Common
{
    /// <summary>
    /// 配置文件管理类 
    /// </summary>
    public sealed class AppConfig
    {
        #region Field
        /// <summary>
        /// 文件路径
        /// </summary>
        private string filePath;

        /// <summary>
        /// 配置文件对象
        /// </summary>
        private Configuration config;
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 配置文件管理类
        /// </summary>
        public AppConfig()
        {

            string webconfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Web.Config");
            string appConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App.Config");

            if (File.Exists(webconfig))
            {
                filePath = webconfig;
            }
            else if (File.Exists(appConfig))
            {
                filePath = appConfig;
            }
            else
            {
                throw new ArgumentNullException("没有找到Web.Config文件或者应用程序配置文件, 请指定配置文件");
            }

            this.config = ConfigurationManager.OpenExeConfiguration(this.filePath);
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取设置参数
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public string GetAppSetting(string key)
        {
            foreach (string item in config.AppSettings.Settings.AllKeys)
            {
                if (item == key)
                {
                    return config.AppSettings.Settings[key].Value.ToString();
                }
            }

            return "";
        }
        #endregion //Method

        #region Property
        /// <summary>
        /// 数据库类型
        /// </summary>
        public string DbType
        {
            get
            {
                return GetAppSetting("DbType");
            }
        }
        #endregion //Property
    }
}
