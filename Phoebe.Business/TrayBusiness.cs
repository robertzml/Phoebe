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
        /// <remarks>
        /// 不含废弃托盘
        /// </remarks>
        public List<Tray> Get()
        {
            return this.context.Trays.Where(r => r.Status != (int)EntityStatus.TrayAbandon).ToList();
        }

        /// <summary>
        /// 按状态获取托盘
        /// </summary>
        /// <param name="status">托盘状态</param>
        /// <returns></returns>
        public List<Tray> Get(EntityStatus status)
        {
            return this.context.Trays.Where(r => r.Status == (int)status).ToList();
        }

        /// <summary>
        /// 获取托盘
        /// </summary>
        /// <param name="id">托盘ID</param>
        /// <returns></returns>
        public Tray Get(int id)
        {
            return this.context.Trays.Find(id);
        }

        /// <summary>
        /// 获取未用托盘
        /// </summary>
        /// <returns></returns>
        public List<Tray> GetUnused()
        {
            return this.context.Trays.Where(r => r.Status == (int)EntityStatus.TrayUnused).ToList();
        }

        /// <summary>
        /// 获取仓库内托盘
        /// </summary>
        /// <param name="warehouseID">仓库ID</param>
        /// <returns></returns>
        public List<Tray> GetInWarehouse(int warehouseID)
        {
            return this.context.Trays.Where(r => r.WarehouseID == warehouseID).ToList();
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

        /// <summary>
        /// 添加托盘
        /// </summary>
        /// <param name="data">托盘数据</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public ErrorCode Create(Tray data, int count)
        {
            try
            {
                data.CreateTime = DateTime.Now;
                data.Status = (int)EntityStatus.TrayUnused;

                for (int i = 0; i < count; i++)
                {
                    Tray tray = new Tray();
                    tray.Width = data.Width;
                    tray.Length = data.Length;
                    tray.CreateTime = data.CreateTime;
                    tray.Remark = data.Remark;
                    tray.Status = data.Status;

                    this.context.Trays.Add(tray);
                }

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 废弃托盘
        /// </summary>
        /// <param name="id">托盘ID</param>
        /// <returns></returns>
        public ErrorCode Abandon(int id)
        {
            try
            {
                var data = this.context.Trays.Find(id);
                if (data == null)
                    return ErrorCode.ObjectNotFound;

                if (data.Status == (int)EntityStatus.TrayInuse)
                    return ErrorCode.TrayInUse;

                data.AbandonTime = DateTime.Now;
                data.Status = (int)EntityStatus.TrayAbandon;

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
