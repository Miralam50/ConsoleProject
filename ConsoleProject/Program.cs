using ConsoleProject.Services;
using ConsoleTables;

namespace MyProject;
class Program
{
    static void Main(string[] args)
    {
        
        int option;

        do
        {
            Console.WriteLine("1. For managing products");
            Console.WriteLine("2. For managing sales");
            Console.WriteLine("0. Exit");
            Console.WriteLine("-----------");
            Console.WriteLine("Enter option:");

            while (!int.TryParse(Console.ReadLine(), out option))
            {
                Console.WriteLine("Invalid number!");
                Console.WriteLine("-----------");
                Console.WriteLine("Enter option:");
            }

            switch (option)
            {
                case 1:
                    SubMenuHelper.ProductsSubMenu();
                    break;
                case 2:
                    SubMenuHelper.SalesSubMenu();
                    break;
                case 0:
                    Console.WriteLine("Bye!");
                    break;
                default:
                    Console.WriteLine("No such option!");
                    break;
            }

        } while (option != 0);
    }
}