using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 统计业务类
    /// </summary>
    public class StatisticBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public StatisticBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 按客户获取分类库存
        /// </summary>
        /// <param name="customerType">客户类型</param>
        /// <param name="customerID">客户ID</param>
        /// <returns></returns>
        public StoreClassifyModel GetClassifyStoreByCustomer(int customerType, int customerID)
        {
            var cargos = from r in this.context.Cargoes
                         where r.Status != (int)EntityStatus.CargoNotIn && r.Status != (int)EntityStatus.CargoStockInReady && r.StoreCount != 0 &&
                            (from s in this.context.Contracts
                             where s.CustomerID == customerID && s.CustomerType == customerType
                             select s.ID).Contains(r.ContractID)
                         select r;

            List<StoreClassifyPlanModel> plans = new List<StoreClassifyPlanModel>();
            foreach (var item in cargos)
            {
                string number = string.Format("{0}-{1}-{2}", item.FirstCategoryID, item.SecondCategoryID, item.ThirdCategoryID == null ? 0 : item.ThirdCategoryID);

                if (plans.Any(r => r.CategoryNumber == number))
                {
                    var model = plans.Single(r => r.CategoryNumber == number);
                    model.StoreCount += item.StoreCount;
                }
                else
                {
                    StoreClassifyPlanModel model = new StoreClassifyPlanModel
                    {
                        CustomerID = customerID,
                        CustomerType = customerType,
                        CategoryNumber = number,
                        FirstCategoryID = item.FirstCategoryID,
                        FirstCategoryName = item.FirstCategory.Name,
                        SecondCategoryID = item.SecondCategoryID,
                        SecondCategoryName = item.SecondCategory.Name,
                        ThirdCategoryID = item.ThirdCategoryID == null ? 0 : item.ThirdCategoryID.Value,
                        ThirdCategoryName = item.ThirdCategory == null ? "" : item.ThirdCategory.Name,
                        StoreCount = item.StoreCount
                    };

                    plans.Add(model);
                }
            }

            StoreClassifyModel data = new StoreClassifyModel();
            data.CustomerID = customerID;
            data.CustomerType = customerType;
            data.FirstStore = new List<StoreFirstCategory>();

            foreach (var firstId in plans.Select(r => r.FirstCategoryID).Distinct())
            {
                StoreFirstCategory first = new StoreFirstCategory();
                first.FirstCategoryID = firstId;
                first.FirstCategoryName = plans.First(r => r.FirstCategoryID == firstId).FirstCategoryName;
                first.SecondStore = new List<StoreSecondCategory>();

                foreach (var secondId in plans.Where(r => r.FirstCategoryID == firstId).Select(s => s.SecondCategoryID).Distinct())
                {
                    StoreSecondCategory second = new StoreSecondCategory();
                    second.SecondCategoryID = secondId;
                    second.SecondCategoryName = plans.First(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId).SecondCategoryName;
                    second.ThirdStore = new List<StoreThirdCategory>();

                    foreach (var thirdId in plans.Where(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId).Select(s => s.ThirdCategoryID).Distinct())
                    {
                        StoreThirdCategory third = new StoreThirdCategory();
                        third.ThirdCategoryID = thirdId;
                        third.ThirdCategoryName = plans.First(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId && r.ThirdCategoryID == thirdId).ThirdCategoryName;
                        third.StoreCount = plans.Single(r => r.FirstCategoryID == firstId && r.SecondCategoryID == secondId && r.ThirdCategoryID == thirdId).StoreCount;

                        second.ThirdStore.Add(third);
                    }

                    second.StoreCount = second.ThirdStore.Sum(r => r.StoreCount);
                    first.SecondStore.Add(second);
                }
                first.StoreCount = first.SecondStore.Sum(r => r.StoreCount);
                data.FirstStore.Add(first);
            }

            data.StoreCount = data.FirstStore.Sum(r => r.StoreCount);
            return data;
        }
        #endregion //Method
    }
}
