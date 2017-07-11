using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cashier;

namespace Cashier
{
    class Comper
    {
        public static void BubbleSort<T>(T[] items,bool newUp) where T : IComparable<T>
        {
            
            if (!newUp)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    for (int j = 0; j < items.Length - i - 1; j++)
                    {
                        if (items[j].CompareTo(items[j + 1]) > 0)
                        {
                            var temp = items[j];
                            items[j] = items[j + 1];
                            items[j + 1] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < items.Length; i++)
                {
                    for (int j = 0; j < items.Length - i - 1; j++)
                    {
                        if (items[j].CompareTo(items[j + 1]) < 0)
                        {
                            var temp = items[j];
                            items[j] = items[j + 1];
                            items[j + 1] = temp;
                        }
                    }
                }
            }
        }
    }
}
