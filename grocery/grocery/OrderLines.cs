using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grocery
{
     class OrderLines
    {
        Product orderProduct;
        int orderPrice;
        int quantity;
        public OrderLines(Product orderProduct, int quantity)
        {
            this.orderProduct = orderProduct;            
            this.quantity = quantity;
            this.orderPrice = orderProduct.ProductPrice;
        }

        public int OrderPrice { get => orderPrice; set => orderPrice = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
