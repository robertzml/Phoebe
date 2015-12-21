using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 仓库业务类
    /// </summary>
    public class WarehouseBusiness
    {
        #region Field
        private PhoebeContext context;

        /// <summary>
        /// 最大层级
        /// </summary>
        private int maxLevel = 6;

        /// <summary>
        /// 库位列表
        /// </summary>
        private List<Warehouse> storageList = new List<Warehouse>();
        #endregion //Field

        #region Constructor
        /// <summary>
        /// 仓库业务类
        /// </summary>
        public WarehouseBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Function
        /// <summary>
        /// 递归获取仓库下的库位
        /// </summary>
        /// <param name="warehouse">仓库</param>
        private void GetStorageRecursive(Warehouse warehouse)
        {
            if (warehouse.ChildrenWarehouse != null || warehouse.ChildrenWarehouse.Count != 0)
            {
                foreach(var item in warehouse.ChildrenWarehouse)
                {
                    GetStorageRecursive(item);
                }
            }
            else
            {
                storageList.Add(warehouse);
            }
        }
        #endregion //Function

        #region Method
        /// <summary>
        /// 获取所有仓库
        /// </summary>
        /// <returns></returns>
        public List<Warehouse> Get()
        {
            return this.context.Warehouses.Where(r => r.Status == 0).ToList();
        }

        /// <summary>
        /// 获取仓库
        /// </summary>
        /// <param name="id">仓库ID</param>
        /// <returns></returns>
        public Warehouse Get(int id)
        {
            return this.context.Warehouses.Find(id);
        }

        /// <summary>
        /// 获取顶级仓库
        /// </summary>
        /// <returns></returns>
        public Warehouse GetTop()
        {
            return this.context.Warehouses.FirstOrDefault(r => r.Hierarchy == 1);
        }

        /// <summary>
        /// 获取仓库下库位
        /// </summary>
        /// <param name="warehouse">仓库</param>
        /// <returns></returns>
        public List<Warehouse> GetLeaves(Warehouse warehouse)
        {
            this.storageList.Clear();
            GetStorageRecursive(warehouse);

            return this.storageList;
        }

        /// <summary>
        /// 添加仓库
        /// </summary>
        /// <param name="data">仓库数据</param>
        /// <returns></returns>
        public ErrorCode Create(Warehouse data)
        {
            try
            {
                if (data.Hierarchy > this.maxLevel)
                    return ErrorCode.WarehouseLevelOverflow;

                if (this.context.Warehouses.Any(r => r.Number == data.Number))
                    return ErrorCode.DuplicateNumber;

                data.Status = 0;

                this.context.Warehouses.Add(data);
                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 编辑仓库
        /// </summary>
        /// <param name="data">仓库数据</param>
        /// <returns></returns>
        public ErrorCode Edit(Warehouse data)
        {
            try
            {
                this.context.Entry(data).State = EntityState.Modified;
                this.context.SaveChanges();
            }
            catch(Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 保存更新
        /// </summary>
        /// <returns></returns>
        public ErrorCode Save()
        {
            try
            {
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
