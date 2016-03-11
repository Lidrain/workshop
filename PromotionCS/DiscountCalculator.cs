using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionCS
{
    public class DiscountCalculator
    {
        private Promotion promotion;

        public DiscountCalculator(Promotion promotion)
        {
            if (promotion == null)
            {
                this.promotion = new Promotion();
                this.promotion.DiscountScheme = 0;
            }
            else
                this.promotion = promotion;
        }

        public Order CalculateDiscount(Order order)
        {
            if (!promotion.IsEnabled)
                return order;

            order.SortBySku();
            switch (promotion.DiscountScheme) {
                case 1:
                    double totalDiscount = 0.0;
                    OrderItem prev = null;
                    Boolean applyDiscount = true;

                    foreach(OrderItem item in order.Items)
                    {
                        if (prev != null) {
                            if (checkStyle(item, prev))
                            {
                                if (applyDiscount)
                                {
                                    totalDiscount += promotion.DiscountPercent * item.Product.Price;
                                    applyDiscount = false;
                                }
                                else
                                    applyDiscount = true;
                            }
                        }
                        prev = item;
                        if (item.Quantity >= 2 && applyDiscount)
                        {
                            if (applyDiscount)
                            {
                                totalDiscount += (promotion.DiscountPercent * item.Product.Price) * (item.Quantity / 2);
                                applyDiscount = false;
                            }
                            else
                                applyDiscount = true;
                        }
                    }
                    order.TotalDiscount = totalDiscount;    
                    break;

                case 2:
                    totalDiscount = 0.0;
                    if (order.Items.Count == 1 && order.Items[0].Quantity == 1)
                    {
                        totalDiscount += promotion.DiscountPercent * order.Items[0].Product.Price;
                    }
                    else
                    {
                        prev = null;
                        Boolean includePrev = true;
                        foreach (OrderItem item in order.Items)
                        {
                            if (prev != null)
                            {
                                if (checkStyle(item, prev))
                                {
                                    totalDiscount += (promotion.SecondDiscount * item.Product.Price) * item.Quantity;

                                    if (includePrev == true)
                                    {
                                        totalDiscount += (promotion.SecondDiscount * prev.Product.Price) * prev.Quantity;
                                        includePrev = false;
                                    }
                                }
                                else 
                                {
                                    if(prev.Quantity <2)
                                        totalDiscount += (promotion.DiscountPercent * prev.Product.Price) * prev.Quantity;
                                    if (item.Quantity >= 2)
                                        totalDiscount += (promotion.SecondDiscount * item.Product.Price) * item.Quantity;
                                    else
                                        totalDiscount += (promotion.DiscountPercent * item.Product.Price) * item.Quantity;
                                    includePrev = true;
                                }
                                    
                            }
                            else
                            {
                                if (item.Quantity >= 2)
                                    totalDiscount += (promotion.SecondDiscount * item.Product.Price) * item.Quantity;
                            }
                            prev = item;
                        }
                    }
                    order.TotalDiscount = totalDiscount;    
                    break;

                case 3:
                    totalDiscount = 0.0;
                    foreach (OrderItem item in order.Items) {
                        if (item.Product.Name.Contains("Invisible Socks")) {
                            totalDiscount = (item.Quantity / 3) * promotion.DiscountPrice;
                        }
                    }
                    Console.WriteLine("total discount: " + totalDiscount);
                    order.TotalDiscount = totalDiscount;
                    break;
                default:
                    break;
            }
            return order;
        }

        private Boolean checkStyle(OrderItem item1, OrderItem item2)
        {
            if (item1.Product.Sku.Split('.')[0].Equals(item2.Product.Sku.Split('.')[0]))
                return true;
            return false;
        }

        private Dictionary<String, int> countItems(Order order) {
            Dictionary<String, int> itemMap = new Dictionary<String, int>();

            foreach (OrderItem item in order.Items) { 
                String style = item.Product.Sku.Split('.')[0].Trim();
                if (itemMap.ContainsKey(style))
                    itemMap[style] = itemMap[style] + item.Quantity;
                else
                    itemMap.Add(style, item.Quantity);
            }

            return itemMap;
        }
    }

}
