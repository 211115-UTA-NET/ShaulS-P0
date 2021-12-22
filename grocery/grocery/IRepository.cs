using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocery
{
    /// <summary>
    /// Use Interface to sperate sql operations from Method done in Local Program
    /// </summary>
    public interface IRepository
    {
        void AddNewCustomer(Customer NewCustomer);
        bool SearchCustomersByName(Customer NewCustomer);

        bool SearchProductByName(Product NewProduct);

        bool SearchStoreByName(Stores NewStore);
        //void Save();
        Order SearchOrderById(int OrderId);
        bool AddNewOrder(Order NewOrder);
        IEnumerable<Stores> DisplayStoreList();
        IEnumerable<Order> orderHistoryByStore(Stores FindStore);
        IEnumerable<Order> orderHistoryByCustomer(Customer FindCustomer);
    }

}
