using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocery
{
    public class Order
    {
        string storeLocation;

        DateTime ordertime;
        
        List<OrderLines> OrdersLines = new List<OrderLines>();
        public Order()
        { }
        int customerId;
        public int CustomerId { get => customerId; set => customerId = value; }
        public string StoreLocation { get => storeLocation; set => storeLocation = value; }
    }
}
