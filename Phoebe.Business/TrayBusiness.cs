using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 托盘业务类
    /// </summary>
    public class TrayBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public TrayBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有托盘
        /// </summary>
        /// <returns></returns>
        public List<Tray> Get()
        {
            return this.context.Trays.ToList();
        }

        /// <summary>
        /// 获取托盘
        /// </summary>
        /// <param name="id">托盘ID</param>
        /// <returns></returns>
        public Tray Get(int id)
        {
            return this.context.Trays.SingleOrDefault(r => r.ID == id);
        }

        /// <summary>
        /// 添加托盘
        /// </summary>
        /// <param name="data">托盘数据</param>
        /// <returns></returns>
        public ErrorCode Create(Tray data)
        {
            try
            {
                data.CreateTime = DateTime.Now;
                data.Status = (int)EntityStatus.TrayUnused;

                this.context.Trays.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Method
    }
}
