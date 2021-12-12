using System;

public class Customer
{

    private int customerId;

    private string firstName;

    private string lastName;

    public int CustomerId { get => customerId; set => customerId = value; }
    public string FirstName { get => firstName; set => firstName = value; }
    public string LastName { get => lastName; set => lastName = value; }
    private static int LastCustomerId;
    public Customer(string FirstName,string LastName)
	{
		this.FirstName = FirstName;
        this.LastName = LastName;
        LastCustomerId++;
        this.CustomerId = LastCustomerId;
    }
	public static int searchCustomer(string firstName, string LastName)
    {
        return 0;
    }
    
}
