using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromotionCS;

namespace TestProject
{
    public class Products
    {
        static Dictionary<string,Product> products = new Dictionary<string, Product>(); 

        static Products()
        {
            products.Add("redDress",    new Product("1001.1", "Red Dress",   100.0));
            products.Add("greenDress",  new Product("1001.2", "Green Dress", 100.0));
            products.Add("blueDress",   new Product("1001.3", "Blue Dress",  100.0));
            products.Add("whiteSocks",  new Product("2001.1", "White Socks", 10.0));
            products.Add("redSocks",    new Product("2001.2", "Red Socks",   10.0));
            products.Add("invisibleSocks", new Product("2001.3", "Invisible Socks", 15));
        }

        public static Product GetProduct(string name)
        {
            return products[name];
        }
    }
}
