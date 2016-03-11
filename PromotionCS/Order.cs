using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PromotionCS
{
    public class Order
    {
        private double totalDiscount=0.0;

        public List<OrderItem> Items { get; set; }
        
        public Order()
        {
            Items = new List<OrderItem>();
        }

        public double TotalPrice
        {
            get
            {
                double total = 0;
                foreach (OrderItem item in Items)
                {
                    total += item.Product.Price*item.Quantity;
                }
                total -= totalDiscount;
                return total;
            }
        }

        public void Add(Product product, int qty)
        {
            OrderItem oi = GetOrderItem(product.Sku);

            if (oi == null)
            {
                oi = new OrderItem();
                oi.Product = product;
                oi.Quantity = qty;
                Items.Add(oi);
                SortBySku();
            }
            else
            {
                oi.Quantity += qty;
            }

        }

        public OrderItem GetOrderItem(string sku)
        {
            return Items.Find(o => o.Product.Sku == sku);
        }

        public void SortBySku()
        {
            Items.Sort(delegate(OrderItem item1, OrderItem item2)
            {
                return item1.Product.Sku.CompareTo(item2.Product.Sku);
            });
        }
        public double TotalDiscount
        {
            get { return totalDiscount; }
            set { totalDiscount = value; }
        }
    }

    public class OrderItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
