using System;
using System.Threading.Tasks;
using WcfClient.ServiceReference1;

namespace WcfClient
{
    internal class Program
    {

        static void Main(string[] args)
        {
            MyData.MyInfo();

            int choice = 0;
  
            do
            {
                Console.WriteLine("Wybierz operację:");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Dodawanie");
                Console.WriteLine("2. Odejmowanie");
                Console.WriteLine("3. Mnożenie");
                Console.WriteLine("4. Dzielenie");
                Console.WriteLine("5. Modulo");
                Console.WriteLine("6. Mnożenie asynchroniczne");
                Console.WriteLine("7. Liczby pierwsze: największa i ich liczba w przedziale");
                Console.WriteLine("0. Wyjście");
                Console.ResetColor();

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Nieprawidłowe wejście.");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        MalCalMenu.Close();
                        break;
                    case 1:
                        MalCalMenu.Add();
                        break;
                    case 2:
                        MalCalMenu.Sub();
                        break;
                    case 3:
                        MalCalMenu.Mul();
                        break;
                    case 4:
                        MalCalMenu.Div();
                        break;
                    case 5:
                        MalCalMenu.Mod();
                        break;
                    case 6:
                        MalCalMenu.HMul();
                        break;
                    case 7:
                        MalCalMenu.PrimeNumbersInRange();
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowe wejście.");
                        break;
                }
            } while (choice != 0);
            Console.ReadKey();
        }

    }
}
