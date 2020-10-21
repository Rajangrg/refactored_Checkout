using Checkout.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Services.Interface
{
    public interface IProduct
    {
        void SetProductPrice(string productPrice);
        void ScanProductItem(string productBarCode);
        Product GetScannedProduct(string productList);
        double CalculateTotalPrice();
    }
}
