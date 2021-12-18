using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace grocery
{
    class Program
    {

        public static String ConsoleReadLine(string Caption)
        {
            string? NewValue;
            do
            {
                Console.WriteLine(Caption);
                NewValue = Console.ReadLine();
                if (NewValue == null) Console.WriteLine("Empty Value,Try again");
            }
            while (NewValue == null);
            return NewValue;
        }
        public static void Main(string[] args)
        {

            string connectionString = File.ReadAllText("C:/Users/shaul/Revature/db.txt");
            IRepository repository = new SqlRepository(connectionString);

            string? InputString = "";
            do
            {
                Console.WriteLine(
@"1. place orders to store locations for customers
2. add a new customer
3. search customers by name
4. display details of an order
5. display all order history of a store location
6. display all order history of a customer
7. Exit");
                InputString = Console.ReadLine();
                if (InputString != "7")
                {
                    switch (InputString) {
                        case "3":
                            Customer FindCustomer;
                            bool Result = false;
                            {
                                FindCustomer = new Customer();
                                Console.WriteLine("Search Customer:");
                                FindCustomer.FirstName = ConsoleReadLine("enter Customer first Name:");
                                FindCustomer.LastName = ConsoleReadLine("enter Customer Last Name:");
                                Result=repository.SearchCustomersByName(FindCustomer);
                                if (Result)
                                    Console.WriteLine("Customer Exists");                                
                                else
                                    Console.WriteLine("Customer Not Found");
                            }
                            while (Result == false) ;
                            break;
                        case "2":
                            Customer NewCustomer = new Customer();
                            NewCustomer.FirstName = ConsoleReadLine("enter Customer first Name:");
                            NewCustomer.LastName = ConsoleReadLine("enter Customer Last Name:");
                            repository.AddNewCustomer (NewCustomer);
                            break;
                    }
                }

            }
            while (InputString != "7");



            // a connection string is a somewhat standardized format to represent all credentials and options
            // needed to open a connection to some remote data source. (in the case of SQL, it will definitely
            // have a server URL, user, password, and database name at least)
            // to build from scratch, look at: either the ADO.NET documentation on SQL Server,
            // or the SQL Server documentation on ADO.NET, or... https://www.connectionstrings.com/

            // let's NOT put our connection strings on github
            //string connectionString = File.ReadAllText("C:/Users/shaul/Revature/db.txt");
            //// instead... some reasonable possibilities: command-line args, environment variables
            //// easier for now - either a gitignored file in the project directory
            //// or a file somewhere outside the git repo entirely

            //using SqlConnection connection = new(connectionString);
            //connection.Open();

            //string commandText = "SELECT * FROM Customer;";

            //using SqlCommand command = new(commandText, connection);

            //using SqlDataReader reader = command.ExecuteReader();

            //while (reader.Read())
            //{
            //    // goes through each row at a time

            //    // several ways to get the data in the current row (by column index)
            //    int id = reader.GetInt32(0);
            //    string FirstName = reader.GetString(1);
            //    //string title2 = reader["Title"].ToString();
            //    //int pages = int.Parse(reader[2].ToString());
            //    string LastName= reader.GetString(2);

            //    Console.WriteLine($"id:{id} Full Name:{FirstName} {LastName}");
            //}

            //List<Customer>? Customers= new List<Customer>();             
            
            //Customer c1 = new Customer("shaul", "stavi");
            //Customer c2 = new Customer("orit", "stavi");
            //Customers.Add(c1);
            //Customers.Add(c2);

            //XmlSerializer serializer = new XmlSerializer(Customers.GetType());
            //try
            //{
            //    using (StreamWriter sw = new StreamWriter("Customers.xml"))
            //    {
            //        serializer.Serialize(sw, Customers);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);                
            //}

            //stream = new FileStream(@"E:\ExampleNew.txt", FileMode.Open, FileAccess.Read);
            //Tutorial objnew = (Tutorial)formatter.Deserialize(stream);

            //Console.WriteLine(objnew.ID);
            //Console.WriteLine(objnew.Name);


        }
    }
}