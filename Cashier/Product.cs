using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier
{
    public class Product : IComparable<Product>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int CompareTo(Product productList)
        {
            return this.Price.CompareTo(productList.Price);
        }
    }
}
