using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoebe.FormClient
{
    using Phoebe.Model;

    /// <summary>
    /// 数据转换类
    /// </summary>
    public static class ModelTranslate
    {
        /// <summary>
        /// 入库单转换
        /// </summary>
        /// <param name="stockIn">入库单</param>
        /// <returns></returns>
        public static List<StockInModel> StockInToModel(StockIn stockIn)
        {
            List<StockInModel> data = new List<StockInModel>();
            foreach (var item in stockIn.StockInDetails)
            {
                StockInModel model = new StockInModel();
                model.Id = item.Id;
                model.StockInId = stockIn.Id;
                model.StoreId = item.StoreId;
                model.ContractId = stockIn.ContractId;
                model.CargoId = item.Store.CargoId;
                model.CategoryId = item.Store.Cargo.CategoryId;
                model.CategoryNumber = item.Store.Cargo.Category.Number;
                model.CategoryName = item.Store.Cargo.Category.Name;
                model.Specification = item.Store.Specification;
                model.InCount = item.Count;
                model.GroupType = item.Store.Cargo.GroupType;
                model.UnitWeight = item.Store.Cargo.UnitWeight;
                model.InWeight = item.InWeight;
                model.UnitVolume = item.Store.Cargo.UnitVolume;
                model.InVolume = item.InVolume;
                model.WarehouseNumber = item.Store.WarehouseNumber;
                model.OriginPlace = item.Store.OriginPlace;
                model.ShelfLife = item.Store.ShelfLife;
                model.Remark = item.Remark;
                model.Status = item.Status;

                data.Add(model);
            }

            return data;
        }

        /// <summary>
        /// 库存记录转出库记录
        /// </summary>
        /// <param name="stores">库存记录</param>
        /// <returns></returns>
        public static List<StockOutModel> StoreToStockOut(List<Store> stores)
        {
            List<StockOutModel> data = new List<StockOutModel>();
            foreach (var item in stores)
            {
                StockOutModel model = new StockOutModel();
                model.StoreId = item.Id;
                model.ContractId = item.Cargo.ContractId;
                model.CargoId = item.CargoId;
                model.CategoryId = item.Cargo.CategoryId;
                model.CategoryNumber = item.Cargo.Category.Number;
                model.CategoryName = item.Cargo.Category.Name;
                model.Specification = item.Specification;
                model.StoreCount = item.StoreCount;
                model.GroupType = item.Cargo.GroupType;
                model.UnitWeight = item.Cargo.UnitWeight;
                model.UnitVolume = item.Cargo.UnitVolume;
                model.WarehouseNumber = item.WarehouseNumber;
                model.InTime = item.InTime;
                model.OriginPlace = item.OriginPlace;
                model.ShelfLife = item.ShelfLife;

                data.Add(model);
            }

            return data;
        }
    }
}
