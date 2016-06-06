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

        public static Phoebe.Model.Report.RStockInModel StockInToReport(StockIn stockIn)
        {
            Phoebe.Model.Report.RStockInModel report = new Model.Report.RStockInModel();
            report.CustomerName = stockIn.Contract.Customer.Name;
            report.UserName = stockIn.User.Name;

            report.Details = new List<Model.Report.RStockInDetailsModel>();
            foreach(var item in stockIn.StockInDetails)
            {
                Model.Report.RStockInDetailsModel detail = new Model.Report.RStockInDetailsModel();
                detail.CategoryNumber = item.Store.Cargo.Category.Number;
                detail.CategoryName = item.Store.Cargo.Category.Name;
                detail.Count = item.Count;
                detail.UnitWeight = item.Store.Cargo.UnitWeight;
                detail.TotalWeight = item.InWeight;
                detail.TotalVolume = item.InVolume;
                detail.Warehouse = item.Store.WarehouseNumber;

                report.Details.Add(detail);
            }

            return report;
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
                model.TotalCount = item.TotalCount;
                model.StoreCount = item.StoreCount;
                model.GroupType = item.Cargo.GroupType;
                model.UnitWeight = item.Cargo.UnitWeight;
                model.UnitVolume = item.Cargo.UnitVolume;
                model.WarehouseNumber = item.WarehouseNumber;
                model.InTime = item.InTime;
                model.MoveTime = item.MoveTime;
                model.OriginPlace = item.OriginPlace;
                model.ShelfLife = item.ShelfLife;

                data.Add(model);
            }

            return data;
        }

        /// <summary>
        /// 出库单转换
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        /// <returns></returns>
        public static List<StockOutModel> StockOutToModel(StockOut stockOut)
        {
            List<StockOutModel> data = new List<StockOutModel>();
            foreach (var item in stockOut.StockOutDetails)
            {
                StockOutModel model = new StockOutModel();
                model.Id = item.Id;
                model.StockOutId = stockOut.Id;
                model.StoreId = item.StoreId;
                model.ContractId = stockOut.ContractId;
                model.CargoId = item.Store.CargoId;
                model.CategoryId = item.Store.Cargo.CategoryId;
                model.CategoryNumber = item.Store.Cargo.Category.Number;
                model.CategoryName = item.Store.Cargo.Category.Name;
                model.Specification = item.Store.Specification;
                model.TotalCount = item.Store.TotalCount;
                model.StoreCount = item.StoreCount;
                model.OutCount = item.Count;
                model.GroupType = item.Store.Cargo.GroupType;
                model.UnitWeight = item.Store.Cargo.UnitWeight;
                model.OutWeight = item.OutWeight;
                model.UnitVolume = item.Store.Cargo.UnitVolume;
                model.OutVolume = item.OutVolume;
                model.WarehouseNumber = item.Store.WarehouseNumber;
                model.InTime = item.Store.InTime;
                model.MoveTime = item.Store.MoveTime;
                model.OriginPlace = item.Store.OriginPlace;
                model.ShelfLife = item.Store.ShelfLife;
                model.Remark = item.Remark;
                model.Status = item.Status;

                data.Add(model);
            }

            return data;
        }

        /// <summary>
        /// 库存记录转移库记录
        /// </summary>
        /// <param name="stores">移库记录</param>
        /// <returns></returns>
        public static List<StockMoveModel> StoreToStockMove(List<Store> stores)
        {
            List<StockMoveModel> data = new List<StockMoveModel>();
            foreach (var item in stores)
            {
                StockMoveModel model = new StockMoveModel();
                model.SourceStoreId = item.Id;
                model.ContractId = item.Cargo.ContractId;
                model.CargoId = item.CargoId;
                model.CategoryId = item.Cargo.CategoryId;
                model.CategoryNumber = item.Cargo.Category.Number;
                model.CategoryName = item.Cargo.Category.Name;
                model.Specification = item.Specification;
                model.TotalCount = item.TotalCount;
                model.StoreCount = item.StoreCount;
                model.GroupType = item.Cargo.GroupType;
                model.UnitWeight = item.Cargo.UnitWeight;
                model.UnitVolume = item.Cargo.UnitVolume;
                model.SourceWarehouseNumber = item.WarehouseNumber;
                model.InTime = item.InTime;
                model.MoveTime = item.MoveTime;
                model.OriginPlace = item.OriginPlace;
                model.ShelfLife = item.ShelfLife;

                data.Add(model);
            }

            return data;
        }

        /// <summary>
        /// 移库单转换
        /// </summary>
        /// <param name="stockMove">移库单对象</param>
        /// <returns></returns>
        public static List<StockMoveModel> StockMoveToModel(StockMove stockMove)
        {
            List<StockMoveModel> data = new List<StockMoveModel>();
            foreach (var item in stockMove.StockMoveDetails)
            {
                StockMoveModel model = new StockMoveModel();
                model.Id = item.Id;
                model.StockMoveId = stockMove.Id;
                model.SourceStoreId = item.SourceStoreId;
                model.NewStoreId = item.NewStoreId;
                model.ContractId = stockMove.ContractId;
                model.CargoId = item.SourceStore.CargoId;
                model.CategoryId = item.SourceStore.Cargo.CategoryId;
                model.CategoryNumber = item.SourceStore.Cargo.Category.Number;
                model.CategoryName = item.SourceStore.Cargo.Category.Name;
                model.Specification = item.SourceStore.Specification;
                model.TotalCount = item.SourceStore.TotalCount;
                model.StoreCount = item.StoreCount;
                model.MoveCount = item.Count;
                model.GroupType = item.SourceStore.Cargo.GroupType;
                model.UnitWeight = item.SourceStore.Cargo.UnitWeight;
                model.MoveWeight = item.MoveWeight;
                model.UnitVolume = item.SourceStore.Cargo.UnitVolume;
                model.MoveVolume = item.MoveVolume;
                model.SourceWarehouseNumber = item.SourceStore.WarehouseNumber;
                model.NewWarehouseNumber = item.NewStore.WarehouseNumber;
                model.InTime = item.SourceStore.InTime;
                model.MoveTime = item.SourceStore.MoveTime;
                model.OriginPlace = item.SourceStore.OriginPlace;
                model.ShelfLife = item.SourceStore.ShelfLife;
                model.Remark = item.Remark;
                model.Status = item.Status;

                data.Add(model);
            }

            return data;
        }
    }
}
