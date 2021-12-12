using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocery
{
    public class StoreInventory
    {
        
        string storeLocation;
        int productId;
        int quantity;

        Dictionary<int, int> Inventory = new Dictionary<int, int>();

        public string StoreLocation { get => storeLocation; set => storeLocation = value; }
    }
}
