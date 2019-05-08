using System;
using System.Collections.Generic;
using System.Text;
using WireBrainCoffee.DataAccess.Model;

namespace WireBrainCoffee.DataAccess
{
    public class CoffeeShopDataProvider
    {
        public IEnumerable<CoffeeShop> LoadCoffeeShops()
        {
            yield return new CoffeeShop { Location = "Frankfrut", BeansInStockInKg = 107 };
            yield return new CoffeeShop { Location = "Freiburg", BeansInStockInKg = 23 };
            yield return new CoffeeShop { Location = "Munich", BeansInStockInKg = 56 };
        }
    }
}
