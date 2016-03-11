using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionCS
{
    public class Promotion
    {
        private double discountPercent;
        private double secondDiscount;
        private int minItems;
        private double usualPrice;
        private double discountPrice;
        private int discountScheme;
        private bool isEnabled = true;

        public Promotion() { }
        public double DiscountPercent
        {
            get { return discountPercent; }
            set { discountPercent = value; }
        }

        public double SecondDiscount
        {
            get { return secondDiscount; }
            set { secondDiscount = value; }
        }
        
        public int MinItems
        {
            get { return minItems; }
            set { minItems = value; }
        }
        
        public double UsualPrice
        {
            get { return usualPrice; }
            set { usualPrice = value; }
        }
        
        public double DiscountPrice
        {
            get { return discountPrice; }
            set { discountPrice = value; }
        }
        
        public int DiscountScheme
        {
            get { return discountScheme; }
            set { discountScheme = value; }
        }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { isEnabled = value; }
        }
    }
}
