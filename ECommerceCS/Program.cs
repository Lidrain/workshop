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
            Order order;
            Console.WriteLine("Press 1 to enable/disable discount.");
            Console.WriteLine("Press 2 change discount amount for any dates.");
            Console.WriteLine("Press 3 to add product to shopping cart.");
            Console.WriteLine("Press 4 to display total price.");
            Console.WriteLine("Press 5 to display shopping cart.");

            String x = Console.ReadLine();
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
                order = new Order();
                Console.WriteLine("Shopping Cart Created.");
            }
            Console.ReadKey();
        }
    }
}
