using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocery
{

    public interface IRepository
    {
        //        IEnumerable<Round> GetAllRoundsOfPlayer(string name);
        //        void AddNewRound(string? player1, string? player2, Round round);
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
