using System;
using System.Collections.Generic;
using WireBrainCoffee.DataAccess.Model;

namespace WireBrainCoffee.ShopInfoTool
{
    internal class HelpCommandHandler : IHelpCommandHandler
    {
        private IEnumerable<CoffeeShop> coffeeShops;

        public HelpCommandHandler(IEnumerable<CoffeeShop> coffeeShops)
        {
            this.coffeeShops = coffeeShops;
        }

        public void HandleCommand()
        {
            Console.WriteLine("> Available cofffee shop commands:");
            foreach (var coffeeshop in coffeeShops)
            {
                Console.WriteLine($"> { coffeeshop.Location}");
            }
        }
    }
}