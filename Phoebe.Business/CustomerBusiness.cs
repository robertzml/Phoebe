using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoebe.Model;
using System.Data.Entity;
using System.ComponentModel;

namespace Phoebe.Business
{
    public class CustomerBusiness
    {
        #region Method
        public BindingList<GroupCustomer> GetGroupCustomers()
        {
            PhoebeContext context = new PhoebeContext();

            context.GroupCustomers.Load();
            var data = context.GroupCustomers.Local.ToBindingList();

            return data;
        }

        public void CreateGroupCustomer(GroupCustomer model)
        {
            PhoebeContext context = new PhoebeContext();
            context.GroupCustomers.Add(model);
            return;
        }
        #endregion //Method
    }
}
