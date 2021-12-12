using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocery
{
    class Product
    {
        int productId;
        int productName;
        int productPrice;
        static int LastProductPrice;
        public Product(int productName, int productPrice)
        {
            LastProductPrice++;
            this.productId = LastProductPrice;
            this.productName = productName;
            this.productPrice = productPrice;
        }

        public int ProductId { get => productId; set => productId = value; }
        public int ProductName { get => productName; set => productName = value; }
        public int ProductPrice { get => productPrice; set => productPrice = value; }
    }

}
