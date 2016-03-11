using PromotionCS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ECommerceCS
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Order order = new Order();
            String x = "0";
            while(!x.Equals("6"))
            {
                Console.WriteLine("\n");
                Console.WriteLine("Press 1 to enable/disable discount.");
                Console.WriteLine("Press 2 change discount amount for any dates.");
                Console.WriteLine("Press 3 to add product to shopping cart.");
                Console.WriteLine("Press 4 to display total price.");
                Console.WriteLine("Press 5 to display shopping cart.");
                Console.WriteLine("Press 6 to exit.");

                x = Console.ReadLine();
                //Console.WriteLine("X"+(char)x);
                if (x.Equals("1"))
                {
                    Console.WriteLine("Entered to enable/disable discount.");
                }
                else if (x.Equals("2"))
                {
                    Console.WriteLine("Entered to enable/disable discount.");
                }
                else if (x.Equals("3"))
                {
                    Console.WriteLine("\n");
                    Console.WriteLine("Select the product to add. NOTE: only 1 quantity");
                    Console.WriteLine("1 - Red Dress $100.00");
                    Console.WriteLine("2 - Blue Dress $100.00");
                    Console.WriteLine("3 - Green Dress $100.00");
                    String y = Console.ReadLine();
                    if (y.Equals("1"))
                    {
                        order.Add(TestProject.Products.GetProduct("redDress"), 1);
                        Console.WriteLine("Red Dress Added.");
                    }
                    else if (x.Equals("2"))
                    {
                        order.Add(TestProject.Products.GetProduct("blueDress"), 1);
                        Console.WriteLine("Blue Dress Added.");
                    }
                    else if (x.Equals("3"))
                    {
                        order.Add(TestProject.Products.GetProduct("greenDress"), 1);
                        Console.WriteLine("Green Dress Added.");
                    }
                    //1001.2, "Green Dress", 100.0
                    //1001.3, "Blue Dress", 100.0
                    //2001.1, "White Socks", 10.0
                    //2001.2, "Red Socks", 10.0
                }
            }

            //Console.ReadKey();
        }
    }
}
