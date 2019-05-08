using System;
using System.Collections.Generic;
using System.Linq;
using WireBrainCoffee.DataAccess.Model;

namespace WireBrainCoffee.ShopInfoTool
{
    internal class CoffeeShopCommandHandler : IHelpCommandHandler
    {
        private IEnumerable<CoffeeShop> coffeeShops;
        private string line;

        public CoffeeShopCommandHandler(IEnumerable<CoffeeShop> coffeeShops, string line)
        {
            this.coffeeShops = coffeeShops;
            this.line = line;
        }

        public void HandleCommand()
        {
            var foundCoffeeShop = coffeeShops
                       .Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase))
                       .ToList();
            if (foundCoffeeShop.Count == 0)
            {
                Console.WriteLine($"> Command '{line}' not found ");
            }
            else if (foundCoffeeShop.Count == 1)
            {
                var coffeeShop = foundCoffeeShop.Single();
                Console.WriteLine($"> Location: {coffeeShop.Location}");
                Console.WriteLine($"> Beans in stock: {coffeeShop.BeansInStockInKg}");
            }
            else
            {
                Console.WriteLine($"> Multiple matching coffee shop commands found:");
                foreach (var coffeeType in foundCoffeeShop)
                {
                    Console.WriteLine($"> {coffeeType.Location}");
                }
            }
        }
    }
}