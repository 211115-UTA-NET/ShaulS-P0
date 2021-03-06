using System;
using System.Text;

namespace grocery
{

    /// <summary>
    /// Customer Record Update and insert data from Database
    /// </summary>
    public class Customer
    {

        private int customerId;

        private string firstName;

        private string lastName;

        public int CustomerId { get => customerId; set => customerId = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        private static IRepository? _repository;
        public static IRepository? Repository { get => _repository; set => _repository = value; }

        public Customer()
        { }
        public Customer(string FirstName, string LastName)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        /// <summary>
        /// Add New Customer Record To The Database 
        /// </summary>
        public void AddNewCustomer()
        {
            if (_repository is not null) _repository.AddNewCustomer(this);
        }
        public bool SearchCustomersByName()
        {
            return _repository is null ? false : _repository.SearchCustomersByName(this);
        }
        /// <summary>
        /// display all order history of a customer
        /// </summary>

        public string orderHistoryByCustomer()
        {
            IEnumerable<Order>? allRecords = null;
            if (_repository is not null) allRecords = _repository.orderHistoryByCustomer(this);

            var summary = new StringBuilder();
            summary.AppendLine($"Order ID\tStore Name\tTotal\tOrder Date");
            summary.AppendLine("---------------------------------------------------------------");
            foreach (var record in allRecords)
            {
                summary.AppendLine($"{record.OrderID}\t\t{record.Store.LocationName} \t${record.Total}\t{record.Ordertime}");
            }
            summary.AppendLine("---------------------------------------------------------------");

            return summary.ToString();



        }



    }

}
