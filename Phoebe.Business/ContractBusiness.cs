using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;

namespace Phoebe.Business
{
    /// <summary>
    /// 合同业务类
    /// </summary>
    public class ContractBusiness
    {
        #region Field
        private PhoebeContext context;
        #endregion //Field

        #region Constructor
        public ContractBusiness()
        {
            this.context = new PhoebeContext();
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取所有合同
        /// </summary>
        /// <returns></returns>
        public List<Contract> Get()
        {
            return this.context.Contracts.OrderByDescending(r => r.SignDate).ToList();
        }

        /// <summary>
        /// 获取合同
        /// </summary>
        /// <param name="id">合同ID</param>
        /// <returns></returns>
        public Contract Get(int id)
        {
            return this.context.Contracts.Find(id);
        }

        /// <summary>
        /// 获取当前正常合同
        /// </summary>
        /// <returns></returns>
        public List<Contract> GetNormal()
        {
            return this.context.Contracts.Where(r => r.Status == 0).OrderByDescending(r => r.SignDate).ToList();
        }

        /// <summary>
        /// 添加合同
        /// </summary>
        /// <param name="data">合同数据</param>
        /// <returns></returns>
        public ErrorCode Create(Contract data)
        {
            try
            {
                data.Status = 0;

                int count = this.context.Contracts.Count(r => r.Number == data.Number);
                if (count > 0)
                    return ErrorCode.ContractDuplicateNumber;

                this.context.Contracts.Add(data);
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
