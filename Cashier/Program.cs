using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cashier
{
    class Program
    {
        static void Main(string[] args)
        {

            Product[] productList = GetProducts();
            bool up;
            bool isAgain;
            do
            {
                isAgain = false;
                Console.WriteLine("输入降升序指令(True or False)");
                string Up = Console.ReadLine();
                if (Up.ToLower() == "true")
                {
                    up = true;
                    Comper.BubbleSort<Product>(productList, up);
                }
                else if (Up.ToLower() == "false")
                {
                    up = false;
                    Comper.BubbleSort<Product>(productList, up);
                }
                else
                {
                    isAgain = true;
                    Console.WriteLine("您的输入有误，请重新输入");
                }

            } while (isAgain);
            while (true)
            {

                List<CalculateProduct> calculateProducts = new List<CalculateProduct>();
                Console.WriteLine("**********************\"天地超市\"**************************");
                Console.WriteLine("品名\t\t单价\t\t代码");
                Console.WriteLine(ShowProductList(productList));


                while (true)
                {
                    Console.WriteLine("请输入代码: ");
                    string inputCode = Console.ReadLine();

                    if (inputCode == "0")
                    {
                        Console.WriteLine("结束结账.");
                        break;
                    }
                    Product p = GetProductByCode(productList, inputCode);
                    if (p == null)
                    {
                        Console.WriteLine("你输入的代码没有找到相应的产品");
                        continue;
                    }
                    PutCount(calculateProducts, p);
                }
                Console.WriteLine("");
                Console.WriteLine("已购清单: ");
                ShowShoppingProduct(calculateProducts);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ReadLine();
            }
        }


        private static bool TryParse(string inputCount, out int outValue, out string message)
        {
            outValue = 0;
            message = null;

            bool result = int.TryParse(inputCount, out outValue);

            if (result == false)
            {
                message = "请输入数字";
                return result;
            }

            if (outValue == 0)
            {
                message = "个数不能为零";
                return false;
            }

            return true;
        }

        private static void PutCount(List<CalculateProduct> calculateProducts, Product p)
        {
            int number;
            string message;

            while (TryParse(Console.ReadLine(), out number, out message) == false)
            {
                Console.WriteLine(message);
            }

            CalculateProduct cp = new CalculateProduct(p, number);
            calculateProducts.Add(cp);
        }


        private static void ShowShoppingProduct(List<CalculateProduct> calculateProducts)
        {
            double sum = 0.0;
            foreach (CalculateProduct item in calculateProducts)
            {
                if (item == null)
                    continue;

                sum += item.Sum;
                Console.WriteLine(item.ShowShoppingProduct());
            }
            Console.WriteLine("总和: " + sum);
        }

        public static Product GetProductByCode(Product[] productList, string inputCode)
        {
            foreach (Product product in productList)
            {
                if (product.Code == inputCode)
                {
                    return product;
                }
            }

            return null;
        }


        public static string ShowProductList(Product[] productList)
        {
            string result = string.Empty;//?
            foreach (Product item in productList)
            {
                result += item.Name + "\t\t" + item.Price + "\t\t" + item.Code + "\r\n";
                //Console.WriteLine(item.Name + "\t\t" + item.Price + "\t\t" + item.Code);
            }
            return result;
        }

        public static Product[] GetProducts()
        {
            Product a1 = new Product { Name = "水杯", Price = 9, Code = "001" };
            Product a2 = new Product { Name = "落地扇", Price = 130, Code = "002" };
            Product a3 = new Product { Name = "圓珠筆", Price = 3, Code = "003" };
            Product a4 = new Product { Name = "電飯煲", Price = 400, Code = "004" };
            Product a5 = new Product { Name = "洗衣粉", Price = 20, Code = "005" };
            Product a6 = new Product { Name = "肥皂", Price = 5, Code = "006" };

            var bookings = new int[6];
            bookings[0] = 1;

            Product[] productList = new Product[6];
            productList[0] = a1;
            productList[1] = a2;
            productList[2] = a3;
            productList[3] = a4;
            productList[4] = a5;
            productList[5] = a6;
            return productList;
        }
    }
}
