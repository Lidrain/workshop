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
            Promotion promo = new Promotion();
            promo.DiscountScheme = 1;
            promo.DiscountPercent = 0.3;
            promo.MinItems = 2;
            DiscountCalculator dc = new DiscountCalculator(promo);

            String x = "0";
            while(!x.Equals("6"))
            {
                Console.WriteLine("\n");
                Console.Clear();
                Console.WriteLine("=================================================");
                Console.WriteLine("Press 0 to select promotion.");
                Console.WriteLine("Press 1 to enable/disable discount.");
                Console.WriteLine("Press 2 change discount amount for any dates.");
                Console.WriteLine("Press 3 to add product to shopping cart.");
                Console.WriteLine("Press 4 to display total price.");
                Console.WriteLine("Press 5 to display shopping cart.");
                Console.WriteLine("Press 6 to exit.");
                Console.WriteLine("=================================================");

                x = Console.ReadLine();
                if (x.Equals("0")) {
                    Console.Clear();
                    Console.WriteLine("Select promotion scheme no (1-3, default: 1): ");
                    x = Console.ReadLine();
                    if (x.Equals("1")) 
                    {
                        promo = new Promotion();
                        promo.DiscountScheme = 1;
                        promo.DiscountPercent = 0.3;
                        promo.MinItems = 2;
                    }

                    else if (x.Equals("2")) 
                    {
                        promo.DiscountScheme = 2;
                        promo.DiscountPercent = 0.1;
                        promo.SecondDiscount = 0.2;
                        promo.MinItems = 2;
                    }
                    else if (x.Equals("3")) 
                    {
                        promo.DiscountScheme = 3;
                        promo.DiscountPrice = 20;
                        promo.MinItems = 3;
                    }
                }

                else if (x.Equals("1"))
                {
                    if (promo.IsEnabled)
                    {
                        promo.IsEnabled = false;
                        Console.WriteLine("Discount is disabled");
                    }
                    else 
                    {
                        promo.IsEnabled = true;
                        Console.WriteLine("Discount is enabled");
                    }

                }
                else if (x.Equals("2"))
                {
                    if (promo.DiscountScheme == 1 || promo.DiscountScheme == 2)
                    {
                        Console.WriteLine("Enter new discount: ");
                        x = Console.ReadLine();
                        double newDiscount = 0.0;
                        Double.TryParse(x, out newDiscount);
                        if (newDiscount > 0)
                        {
                            promo.DiscountPercent = newDiscount;
                        }
                    }
                    else {
                        Console.WriteLine("Enter new discount value: ");
                        x = Console.ReadLine();
                        double newDiscount = 0.0;
                        Double.TryParse(x, out newDiscount);
                        if (newDiscount > 0)
                        {
                            promo.DiscountPrice = newDiscount;
                        }
                    }
                }

                else if (x.Equals("3"))
                {
                    String y = "0";
                    while (!y.Equals("5")) { 
                        Console.WriteLine("\n");
                        Console.Clear();
                        Console.WriteLine("=================================================");
                        Console.WriteLine("Select the product to add. NOTE: only 1 quantity");
                        Console.WriteLine("1 - Red Dress $100.00");
                        Console.WriteLine("2 - Blue Dress $100.00");
                        Console.WriteLine("3 - Green Dress $100.00");
                        Console.WriteLine("4 - White Socks $10.00");
                        Console.WriteLine("5 - Return to main manu.");
                        Console.WriteLine("=================================================");
                        List<OrderItem> list = order.Items;
                        Console.Write("[Current items in cart: ");
                        
                        if (list.Count == 0)
                        {
                            Console.Write("-Empty-");
                        }
                        for (int i = 0; i < list.Count; i++)
                        {
                            OrderItem oi = list[i];
                            if(i>0)
                                Console.Write(",");
                            Console.Write(oi.Product.Name);
                        }
                        Console.Write("] ");
                        y = Console.ReadLine();
                        if (y.Equals("1"))
                        {
                            order.Add(TestProject.Products.GetProduct("redDress"), 1);
                            Console.WriteLine("Red Dress Added.");
                        }
                        else if (y.Equals("2"))
                        {
                            order.Add(TestProject.Products.GetProduct("blueDress"), 1);
                            Console.WriteLine("Blue Dress Added.");
                        }
                        else if (y.Equals("3"))
                        {
                            order.Add(TestProject.Products.GetProduct("greenDress"), 1);
                            Console.WriteLine("Green Dress Added.");
                        }
                        else if (y.Equals("4"))
                        {
                            order.Add(TestProject.Products.GetProduct("whiteSocks"), 1);
                            Console.WriteLine("White Socks Added.");
                        }
                        else if (y.Equals("5"))
                        {
                            //Console.WriteLine("Going back to main.");
                            break;
                        }
                        //System.Threading.Thread.Sleep(1500);
                        //1001.2, "Green Dress", 100.0
                        //1001.3, "Blue Dress", 100.0
                        //2001.1, "White Socks", 10.0
                        //2001.2, "Red Socks", 10.0
                    }
                }
                else if (x.Equals("4"))
                {
                    dc.CalculateDiscount(order);
                    //Console.WriteLine("Items in shopping cart:");
                    DiscountCalculator dc = new DiscountCalculator(promo);
                    Order newOrder = dc.CalculateDiscount(order);
                    Console.WriteLine("Total Price: " + newOrder.TotalPrice);
                }
                else if (x.Equals("5"))
                {
                    //Console.WriteLine("Items in shopping cart:");
                    Console.WriteLine("List of items in shopping cart: ");
                    List<OrderItem> list = order.Items;
                    for(int i=0;i<list.Count;i++){
                        OrderItem oi = list[i];
                        Console.WriteLine(i+". "+oi.Product.Name);
                    }
                    
                }
                
                System.Threading.Thread.Sleep(1500);
            }
            Console.WriteLine("Exit Application");
            //Console.ReadKey();
        }
    }
}
