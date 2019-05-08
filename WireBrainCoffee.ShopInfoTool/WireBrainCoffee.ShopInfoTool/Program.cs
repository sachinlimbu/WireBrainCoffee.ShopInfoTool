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
                var commandHandler = string.Equals("help", line, StringComparison.OrdinalIgnoreCase)
                    ? new HelpCommandHandler(coffeeShops) as IHelpCommandHandler
                    : new CoffeeShopCommandHandler(coffeeShops, line);

                commandHandler.HandleCommand();


                //if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                //{
                //    commandHandler = new HelpCommandHandler(coffeeShops);
                //    commandHandler.HandleCommand();
                //}
                //else
                //{
                //    commandHandler = new CoffeeShopCommandHandler(coffeeShops, line);
                //    commandHandler.HandleCommand();
                //}
            }
        }
    }
}
