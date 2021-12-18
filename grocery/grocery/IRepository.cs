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
        //void Save();
    }

}
