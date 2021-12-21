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
        private int orderID;
        DateTime ordertime;
        double total;
        List<OrderLines> ordersLines;//= new List<OrderLines>();
        static readonly int maxQuantity = 100;
        private Customer customer;
        private Stores store;
        private static IRepository? _repository;
        public static IRepository? Repository { get => _repository; set => _repository = value; }
        public static Order SearchOrderById(int OrderId)
        {
            return _repository is null ? null : _repository.SearchOrderById(OrderId);
        }

        public bool CheckOrderValidQuantity(ref string strSummary)
        {
            bool result = true;
            var summary = new StringBuilder();
            foreach (var record in this.OrdersLines)
            {

                if (record.Quantity > MaxQuantity)
                {
                    result = false;
                    summary.AppendLine($"Product\t{record.OrderProduct.ProductName}\t{record.Quantity}");
                }
            }
            if (result == false)
            {
                summary.Insert(0, $"Order Was Rejected exceed max quntity of {MaxQuantity} on Products:\n");
                strSummary = summary.ToString();
            }
            return result;
        }
        public bool AddNewOrder(ref string strSummary)
        {
            bool result = false;
            result = this.CheckOrderValidQuantity(ref strSummary);
            if (result == true)
                return _repository is null ? false : _repository.AddNewOrder(this);
            else
                return false;
        }
        public string DisplayDetailsOrder()
        {
            var summary = new StringBuilder();
            summary.AppendLine($"Order Date\t{this.Ordertime}\t\tCustomer Name\t{this.customer.FirstName} {this.customer.LastName}\t\tAmount");
            summary.AppendLine($"Product\t\t\tQuantity\t\tPrice\t\tAmount");
            summary.AppendLine("---------------------------------------------------------------");
            foreach (var record in this.OrdersLines)
            {
                summary.AppendLine($"{record.OrderProduct.ProductName }\t{record.Quantity}\t\t{record.OrderPrice}\t\t{record.Quantity * record.OrderPrice }");
            }
            summary.AppendLine("---------------------------------------------------------------");
            summary.AppendLine($"Order Total\t{this.Total}");
            return summary.ToString();

        }


        public Order(Customer UpdateCustomer, Stores UpdateStore)
        {
            if (UpdateCustomer is not null) customer = UpdateCustomer;
            if (UpdateStore is not null) store = UpdateStore;
            this.ordertime = DateTime.Now;
        }
        public Order(Customer UpdateCustomer, Stores UpdateStore, DateTime ordertime)
        {
            if (UpdateCustomer is not null) customer = UpdateCustomer;
            if (UpdateStore is not null) store = UpdateStore;
            this.ordertime = ordertime;
        }

        public Order(Customer UpdateCustomer, Stores UpdateStore, DateTime ordertime, double Total)
        {
            if (UpdateCustomer is not null) customer = UpdateCustomer;
            if (UpdateStore is not null) store = UpdateStore;
            this.Total = Total;
            this.ordertime = ordertime;
        }
        public Order(Customer UpdateCustomer, Stores UpdateStore, DateTime ordertime, double Total, int orderID)
        {
            if (UpdateCustomer is not null) customer = UpdateCustomer;
            if (UpdateStore is not null) store = UpdateStore;
            this.Total = Total;
            this.ordertime = ordertime;
            this.orderID = orderID;
        }

        public int CustomerId { get => Customer.CustomerId; set => Customer.CustomerId = value; }
        public string StoreLocation { get => storeLocation; set => storeLocation = value; }
        public Customer Customer { get => customer; set => customer = value; }
        public Stores Store { get => store; set => store = value; }
        public List<OrderLines> OrdersLines
        {
            get
            {
                if (ordersLines == null)
                {
                    ordersLines = new List<OrderLines>();
                }
                return ordersLines;
            }

            set
            {
                ordersLines = value;
            }
        }
        public DateTime Ordertime { get => ordertime; set => ordertime = value; }
        public int OrderID { get => orderID; set => orderID = value; }
        public double Total { get => total; set => total = value; }

        public static int MaxQuantity => maxQuantity;
    }
}
