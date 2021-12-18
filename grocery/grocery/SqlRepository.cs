using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocery
{
    internal class SqlRepository: IRepository
    {

        private readonly string _connectionString;

        public SqlRepository(string connectionString)
        {
            _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public void AddNewCustomer(Customer NewCustomer)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();
            string cmdText = @"INSERT INTO dbo.Customer (FirstName,LastName) VALUES (@FirstName,@LastName);
                                SELECT CustomerID FROM dbo.Customer WHERE FirstName = @FirstName and LastName =@LastName ;";
            using SqlCommand cmd = new(cmdText, connection);
            cmd.Parameters.AddWithValue("@FirstName", NewCustomer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", NewCustomer.LastName);
            using SqlDataReader reader = cmd.ExecuteReader();

            reader.Read();
            NewCustomer.CustomerId=reader.GetInt32(0);
        }

        public bool SearchCustomersByName(Customer findCustomer)
        {
            using SqlConnection connection = new(_connectionString);
            connection.Open();

            using SqlCommand cmd = new(
                @"SELECT CustomerId
                  FROM dbo.customer
                  WHERE FirstName = @FirstName and LastName=@LastName ",
                connection);

            cmd.Parameters.AddWithValue("@FirstName", findCustomer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", findCustomer.LastName);
            using SqlDataReader reader = cmd.ExecuteReader();
            bool Result=false;
            if (reader.Read())
            {
                Result = true;
                findCustomer.CustomerId = reader.GetInt32(0);
            }
            connection.Close();            
                return Result;
        }
    }

}
