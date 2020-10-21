using Checkout.Entity;
using Checkout.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Checkout.Services
{
    public class ProductCalculator : IProduct
    {
        protected List<Product> productDetail;
        protected Dictionary<Product, int> totalProductCount = new Dictionary<Product, int>();

        public void SetProductPrice(string jsonStr)
        {
            productDetail = JsonConvert.DeserializeObject<List<Product>>(jsonStr); //passing the json file value here
        }

        public double CalculateTotalPrice()
        {
            return totalProductCount.Sum(product => product.Key.CalculateTotal(product.Value));
        }

        public void ScanProductItem(string productBarCode)
        {
            var product = GetScannedProduct(productBarCode);
            if (product != null)
            {
                //checking for items
                if (totalProductCount.ContainsKey(product))
                    totalProductCount[product]++;
                else
                    totalProductCount[product] = 1;
            }
        }

        public Product GetScannedProduct(string productCode)
        {
            return productDetail.SingleOrDefault(product => product.priceBarCode == productCode); //return only item from productDetail
        }
    }
}
