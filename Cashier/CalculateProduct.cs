using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier
{
    public class CalculateProduct
    {
        public CalculateProduct(Product p, int count)
        {
            Product = p;
            Count = count;
            Sum = p.Price* Count;
        }

        public Product Product { get;  }

        public int Count { get;  }

        public double Sum { get; }

        public string ShowShoppingProduct()
        {
            return Product.Name + "\t\t" + Count + "\t\t" + Product.Price + "\t\t" + Sum;
        }
    }
}
