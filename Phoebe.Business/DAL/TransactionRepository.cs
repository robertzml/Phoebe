using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace Phoebe.Business.DAL
{
    using Phoebe.Base;
    using Phoebe.Model;

    /// <summary>
    /// 事务操作Repository
    /// </summary>
    public class TransactionRepository : SqlDataAccess<PhoebeContext>
    {
        #region Contract Trans
        /// <summary>
        /// 强制删除合同业务
        /// </summary>
        /// <param name="contract">合同对象</param>
        /// <returns></returns>
        public ErrorCode ContractForceDeleteTrans(Contract contract)
        {
            try
            {
                int customerId = contract.CustomerId;

                //delete the settlement
                var settles = this.context.Settlements.Where(r => r.CustomerId == customerId);
                if (settles.Count() != 0)
                {
                    this.context.Settlements.RemoveRange(settles);
                }

                //delete the stock in
                var stockIns = this.context.StockIns.Where(r => r.ContractId == contract.Id);
                if (stockIns.Count() != 0)
                {
                    this.context.StockIns.RemoveRange(stockIns);
                }

                //delete the stock out
                var stockOuts = this.context.StockOuts.Where(r => r.ContractId == contract.Id);
                if (stockOuts.Count() != 0)
                {
                    this.context.StockOuts.RemoveRange(stockOuts);
                }

                //delete the stock move
                var stockMoves = this.context.StockMoves.Where(r => r.ContractId == contract.Id);
                if (stockMoves.Count() != 0)
                {
                    this.context.StockMoves.RemoveRange(stockMoves);
                }                

                //delte the stores
                var stores = this.context.Stores.Where(r => r.Cargo.ContractId == contract.Id);
                if (stores.Count() != 0)
                {
                    this.context.Stores.RemoveRange(stores);
                }
                this.context.SaveChanges();

                //delete the cargos
                var cargos = this.context.Cargoes.Where(r => r.ContractId == contract.Id);
                if (cargos.Count() != 0)
                {
                    this.context.Cargoes.RemoveRange(cargos);
                }

                this.context.Contracts.Remove(contract);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception e)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Contract Trans

        #region StockIn Trans
        /// <summary>
        /// 新建入库事务
        /// </summary>
        /// <param name="stockIn">入库单对象</param>
        /// <param name="billing">计费对象</param>
        /// <param name="details">入库记录对象</param>
        /// <param name="stores">库存对象</param>
        /// <returns></returns>
        public ErrorCode StockInAddTrans(StockIn stockIn, Billing billing, List<StockInDetail> details, List<Store> stores)
        {
            try
            {
                // add stock in
                this.context.StockIns.Add(stockIn);

                // add billing
                this.context.Billings.Add(billing);

                // add stores
                this.context.Stores.AddRange(stores);

                // add stock in details
                this.context.StockInDetails.AddRange(details);

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 入库确认事务
        /// </summary>
        /// <param name="stockIn">入库单对象</param>
        /// <returns></returns>
        public ErrorCode StockInConfirmTrans(StockIn stockIn)
        {
            try
            {
                stockIn.Status = (int)EntityStatus.StockIn;
                stockIn.Billing.Status = (int)EntityStatus.Normal;

                foreach (var item in stockIn.StockInDetails)
                {
                    item.Status = (int)EntityStatus.StockIn;
                    item.Store.Status = (int)EntityStatus.StoreIn;
                }

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 入库修改事务
        /// </summary>
        /// <param name="stockIn">入库单数据</param>
        /// <param name="billing">计费数据</param>
        /// <param name="details">入库记录数据</param>
        /// <param name="stores">库存数据</param>
        /// <returns></returns>
        public ErrorCode StockInUpdateTrans(StockIn stockIn, Billing billing, List<StockInDetail> details, List<Store> stores)
        {
            try
            {
                //remove the old details and stores
                List<StockInDetail> oldDetails = new List<StockInDetail>();
                List<Store> oldStores = new List<Store>();
                foreach (var item in stockIn.StockInDetails)
                {
                    oldDetails.Add(item);
                    oldStores.Add(item.Store);
                }
                this.context.StockInDetails.RemoveRange(oldDetails);
                this.context.Stores.RemoveRange(oldStores);

                // modify stockIn and billing
                this.context.Entry(stockIn).State = EntityState.Modified;
                this.context.Entry(billing).State = EntityState.Modified;

                // add stores
                this.context.Stores.AddRange(stores);

                // add stock in details
                this.context.StockInDetails.AddRange(details);

                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 入库删除事务
        /// </summary>
        /// <param name="stockIn">入库单对象</param>
        /// <param name="stores">库存对象</param>
        /// <returns></returns>
        public ErrorCode StockInDeleteTrans(StockIn stockIn, List<Store> stores)
        {
            try
            {
                // delete stock in with cascade
                this.context.StockIns.Remove(stockIn);

                // delete store
                this.context.Stores.RemoveRange(stores);

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 入库撤回事务
        /// </summary>
        /// <param name="stockIn">入库单对象</param>
        /// <returns></returns>
        public ErrorCode StockInRevertTrans(StockIn stockIn)
        {
            try
            {
                stockIn.Status = (int)EntityStatus.StockInReady;
                stockIn.Billing.Status = (int)EntityStatus.BillingNotInit;

                foreach (var item in stockIn.StockInDetails)
                {
                    item.Status = (int)EntityStatus.StockInReady;
                    item.Store.Status = (int)EntityStatus.StoreReady;
                }

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //StockIn Trans

        #region StockOut Trans
        /// <summary>
        /// 新建出库事务
        /// </summary>
        /// <param name="stockOut">出库单数据</param>
        /// <param name="details">出库记录数据</param>
        /// <returns></returns>
        public ErrorCode StockOutAddTrans(StockOut stockOut, List<StockOutDetail> details)
        {
            try
            {
                // add stock out
                this.context.StockOuts.Add(stockOut);

                // add stock out details
                this.context.StockOutDetails.AddRange(details);

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 出库确认事务
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        /// <returns></returns>
        public ErrorCode StockOutConfirmTrans(StockOut stockOut)
        {
            try
            {
                stockOut.Status = (int)EntityStatus.StockOut;

                // change store count and status
                foreach (var item in stockOut.StockOutDetails)
                {
                    var store = item.Store;
                    item.StoreCount = store.StoreCount;

                    if (store.StoreCount == item.Count) // all stock out
                    {
                        store.StoreCount = 0;
                        store.StoreWeight = 0;
                        store.StoreVolume = 0;
                        store.OutTime = stockOut.OutTime;
                        store.Destination = (int)DestinationType.StockOut;
                        store.Status = (int)EntityStatus.StoreOut;
                    }
                    else
                    {
                        store.StoreCount -= item.Count;
                        store.StoreWeight -= item.OutWeight;
                        store.StoreVolume -= item.OutVolume;
                    }

                    item.Status = (int)EntityStatus.StockOut;
                }

                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 出库编辑事务
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        /// <param name="details">出库记录</param>
        /// <returns></returns>
        public ErrorCode StockOutUpdateTrans(StockOut stockOut, List<StockOutDetail> details)
        {
            try
            {
                // remove old stockout details
                List<StockOutDetail> oldDetails = new List<StockOutDetail>();
                foreach (var item in stockOut.StockOutDetails)
                {
                    oldDetails.Add(item);
                }
                this.context.StockOutDetails.RemoveRange(oldDetails);

                // edit stock out
                this.context.Entry(stockOut).State = EntityState.Modified;

                // add new stock out details
                this.context.StockOutDetails.AddRange(details);

                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 出库撤回事务
        /// </summary>
        /// <param name="stockOut">出库单对象</param>
        /// <returns></returns>
        public ErrorCode StockOutRevertTrans(StockOut stockOut)
        {
            try
            {
                stockOut.Status = (int)EntityStatus.StockOutReady;

                foreach (var item in stockOut.StockOutDetails)
                {
                    item.Status = (int)EntityStatus.StockOutReady;

                    var store = item.Store;

                    store.StoreCount += item.Count;
                    store.StoreWeight += item.OutWeight;
                    store.StoreVolume += item.OutVolume;
                    store.OutTime = null;
                    store.Destination = null;
                    store.Status = (int)EntityStatus.StoreIn;
                }

                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //StockOut Trans

        #region StockMove Trans
        /// <summary>
        /// 移库新增事务
        /// </summary>
        /// <param name="stockMove">移库单对象</param>
        /// <param name="details">移库记录</param>
        /// <param name="stores">新库存记录</param>
        /// <returns></returns>
        public ErrorCode StockMoveAddTrans(StockMove stockMove, List<StockMoveDetail> details, List<Store> stores)
        {
            try
            {
                // add stock move
                this.context.StockMoves.Add(stockMove);

                // add new stores
                this.context.Stores.AddRange(stores);

                // add stock move details
                this.context.StockMoveDetails.AddRange(details);

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 移库确认事务
        /// </summary>
        /// <param name="stockMove">移库单对象</param>
        /// <returns></returns>
        public ErrorCode StockMoveConfirmTrans(StockMove stockMove)
        {
            try
            {
                stockMove.Status = (int)EntityStatus.StockMove;

                // change store count and status
                foreach (var item in stockMove.StockMoveDetails)
                {
                    var sourceStore = item.SourceStore;
                    item.StoreCount = sourceStore.StoreCount;

                    if (sourceStore.StoreCount == item.Count) // all stock out
                    {
                        sourceStore.StoreCount = 0;
                        sourceStore.StoreWeight = 0;
                        sourceStore.StoreVolume = 0;
                        sourceStore.OutTime = stockMove.MoveTime;
                        sourceStore.Destination = (int)DestinationType.StockMove;
                        sourceStore.Status = (int)EntityStatus.StoreOut;
                    }
                    else
                    {
                        sourceStore.StoreCount -= item.Count;
                        sourceStore.StoreWeight -= item.MoveWeight;
                        sourceStore.StoreVolume -= item.MoveVolume;
                    }

                    var newStore = item.NewStore;
                    newStore.Status = (int)EntityStatus.StoreIn;

                    item.Status = (int)EntityStatus.StockMove;
                }

                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 移库编辑事务
        /// </summary>
        /// <param name="stockMove">移库单对象</param>
        /// <param name="details">移库信息</param>
        /// <param name="stores">新库存</param>
        /// <returns></returns>
        public ErrorCode StockMoveUpdateTrans(StockMove stockMove, List<StockMoveDetail> details, List<Store> stores)
        {
            try
            {
                //remove the old details and stores
                List<StockMoveDetail> oldDetails = new List<StockMoveDetail>();
                List<Store> oldStores = new List<Store>();
                foreach (var item in stockMove.StockMoveDetails)
                {
                    oldDetails.Add(item);
                    oldStores.Add(item.NewStore);
                }
                this.context.StockMoveDetails.RemoveRange(oldDetails);
                this.context.Stores.RemoveRange(oldStores);

                //modify the stock move
                this.context.Entry(stockMove).State = EntityState.Modified;

                //add new stores
                this.context.Stores.AddRange(stores);

                //add stock move details
                this.context.StockMoveDetails.AddRange(details);

                this.context.SaveChanges();
                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 删除移库事务
        /// </summary>
        /// <param name="stockMove">移库单对象</param>
        /// <param name="stores">新库存对象</param>
        /// <returns></returns>
        public ErrorCode StockMoveDeleteTrans(StockMove stockMove, List<Store> stores)
        {
            try
            {
                // delete stock move with cascade
                this.context.StockMoves.Remove(stockMove);

                // delete new  store
                this.context.Stores.RemoveRange(stores);

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }

        /// <summary>
        /// 移库撤回事务
        /// </summary>
        /// <param name="stockMove">移库单对象</param>
        /// <returns></returns>
        public ErrorCode StockMoveRevertTrans(StockMove stockMove)
        {
            try
            {
                stockMove.Status = (int)EntityStatus.StockMoveReady;

                foreach (var item in stockMove.StockMoveDetails)
                {
                    item.Status = (int)EntityStatus.StockMoveReady;

                    var sourceStore = item.SourceStore;
                    sourceStore.StoreCount += item.Count;
                    sourceStore.StoreWeight += item.MoveWeight;
                    sourceStore.StoreVolume += item.MoveVolume;
                    sourceStore.OutTime = null;
                    sourceStore.Destination = null;
                    sourceStore.Status = (int)EntityStatus.StoreIn;

                    item.NewStore.Status = (int)EntityStatus.StoreMoveReady;
                }

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //StockMove Trans

        #region Store Trans
        /// <summary>
        /// 库存修正事务
        /// </summary>
        /// <param name="store">库存记录</param>
        /// <param name="flows">流水记录</param>
        /// <returns></returns>
        public ErrorCode StoreFixTrans(Store store, IEnumerable<StockFlow> flows)
        {
            try
            {
                int totalCount = store.TotalCount;
                int remainCount = totalCount;

                foreach (var flow in flows)
                {
                    if (flow.Type == StockFlowType.StockIn || flow.Type == StockFlowType.StockMoveIn)
                        continue;

                    if (flow.Type == StockFlowType.StockOut)
                    {
                        var so = RepositoryFactory<StockOutDetailsRepository>.Instance.FindById(flow.StockId);
                        so.StoreCount = remainCount;
                        remainCount = remainCount - so.Count;
                    }

                    if (flow.Type == StockFlowType.StockMoveOut)
                    {
                        var sm = RepositoryFactory<StockMoveDetailsRepository>.Instance.FindById(flow.StockId);
                        sm.StoreCount = remainCount;
                        remainCount = remainCount - sm.Count;
                    }

                    if (remainCount == 0)
                    {
                        store.OutTime = flow.FlowDate;
                        if (flow.Type == StockFlowType.StockOut)
                            store.Destination = (int)DestinationType.StockOut;
                        else
                            store.Destination = (int)DestinationType.StockMove;
                    }
                }

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //Store Trans

        #region Settlement Trans
        /// <summary>
        /// 结算添加业务
        /// </summary>
        /// <param name="settle">结算信息</param>
        /// <param name="details">详细记录</param>
        /// <returns></returns>
        public ErrorCode SettlementAddTrans(Settlement settle, List<SettlementDetail> details)
        {
            try
            {
                this.context.Settlements.Add(settle);
                this.context.SettlementDetails.AddRange(details);

                this.context.SaveChanges();
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }

            return ErrorCode.Success;
        }
        #endregion //Settlement Trans

        #region Ice Trans
        /// <summary>
        /// 冰块流水添加业务
        /// </summary>
        /// <param name="iceFlow">冰块流水</param>
        /// <returns></returns>
        public ErrorCode IceFlowAddTrans(IceFlow iceFlow)
        {
            try
            {
                var store = this.context.IceStores.Single(r => r.Type == iceFlow.IceType);

                IceFlowType flowType = (IceFlowType)iceFlow.FlowType;
                if (flowType == IceFlowType.CompleteStockIn || flowType == IceFlowType.FragmentStockIn)
                {
                    store.Count += iceFlow.FlowCount;
                    store.Weight += iceFlow.FlowWeight;
                }
                else if (flowType == IceFlowType.CompleteMakeOut || flowType == IceFlowType.CompleteSaleOut || flowType == IceFlowType.FragmentSaleOut)
                {
                    store.Count -= iceFlow.FlowCount;
                    store.Weight -= iceFlow.FlowWeight;

                    if (store.Count < 0)
                        return ErrorCode.IceOutCountOverflow;
                    if (store.Weight < 0)
                        return ErrorCode.IceOutWeightOverflow;
                }

                this.context.Entry(store).State = EntityState.Modified;
                this.context.IceFlows.Add(iceFlow);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch (Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 冰块销售添加业务
        /// </summary>
        /// <param name="iceSale">冰块销售对象</param>
        /// <param name="iceFlow">冰块流水对象</param>
        /// <returns></returns>
        public ErrorCode IceSaleAddTrans(IceSale iceSale, IceFlow iceFlow)
        {
            try
            {
                //set ice store
                var store = this.context.IceStores.Single(r => r.Type == iceFlow.IceType);
                store.Count -= iceFlow.FlowCount;
                store.Weight -= iceFlow.FlowWeight;

                if (store.Count < 0)
                    return ErrorCode.IceOutCountOverflow;
                if (store.Weight < 0)
                    return ErrorCode.IceOutWeightOverflow;

                this.context.Entry(store).State = EntityState.Modified;
                this.context.IceFlows.Add(iceFlow);
                this.context.IceSales.Add(iceSale);
                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch(Exception)
            {
                return ErrorCode.Exception;
            }
        }

        /// <summary>
        /// 删除冰块流水记录
        /// </summary>
        /// <param name="iceFlow">冰块流水记录</param>
        /// <returns></returns>
        public ErrorCode IceFlowDeleteTrans(IceFlow iceFlow)
        {
            try
            {
                var store = this.context.IceStores.Single(r => r.Type == iceFlow.IceType);
                IceFlowType flowType = (IceFlowType)iceFlow.FlowType;
                if (flowType == IceFlowType.CompleteStockIn || flowType == IceFlowType.FragmentStockIn)
                {
                    store.Count -= iceFlow.FlowCount;
                    store.Weight -= iceFlow.FlowWeight;

                    if (store.Count < 0)
                        return ErrorCode.IceDeleteCountOverflow;
                    if (store.Weight < 0)
                        return ErrorCode.IceDeleteWeightOverflow;
                }
                else if (flowType == IceFlowType.CompleteMakeOut || flowType == IceFlowType.CompleteSaleOut || flowType == IceFlowType.FragmentSaleOut)
                {
                    store.Count += iceFlow.FlowCount;
                    store.Weight += iceFlow.FlowWeight;
                }

                this.context.Entry(store).State = EntityState.Modified;
                this.context.IceFlows.Remove(iceFlow);

                this.context.SaveChanges();

                return ErrorCode.Success;
            }
            catch(Exception)
            {
                return ErrorCode.Exception;
            }
        }
        #endregion //IceTrans
    }
}
