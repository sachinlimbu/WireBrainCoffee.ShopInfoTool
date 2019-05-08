using System;
using System.Linq;
using WireBrainCoffee.DataAccess;

namespace WireBrainCoffee.ShopInfoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wired Brain Coffee - Shop Info Tool!");
            Console.WriteLine("Write 'help' to list available coffee shop commands, " + "Write 'quit' to exit application");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while (true)
            {
                var line = Console.ReadLine();
                var coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();

                if (string.Equals("quit", line, StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }


                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shop commands:");
                    foreach (var coffeeShop in coffeeShops)
                    {
                        Console.WriteLine($">" + coffeeShop.Location);
                    }
                }
                else
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
    }
}
