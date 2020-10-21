using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Checkout.Entity
{
    public class Product
    {
        public string priceBarCode { get; set; }
        public Dictionary<int, double> pricePerUnit { get; set; } // for faster processing as use hash lookup 

        public double CalculateTotal(int itemBought)
        {
            double total = 0;
            foreach (var price in pricePerUnit.OrderByDescending(item => item.Key))
            {
                //running a loop as there are mulitple price for the item
                int itemDeal = itemBought / price.Key;
                total += itemDeal * price.Value;
                itemBought -= itemDeal * price.Key;
            }
            return total;
        }
    }
}