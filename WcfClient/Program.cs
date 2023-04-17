using System;
using System.Threading.Tasks;
using WcfClient.ServiceReference1;

namespace WcfClient
{
    internal class Program
    {
        static async Task<int> callHMultiply(int val1, int val2, CalculatorClient myClient2)
        {
            Console.WriteLine("2... Wywołano callHMultiplyAsync");
            int result = await myClient2.HMultiplyAsync(val1, val2);
            Console.WriteLine("2... Zakończono callHMultiplyAsync");
            return result;
        }

        static void Main(string[] args)
        {
            MyData.MyInfo();

            int operation = 0;
  
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

                if (!int.TryParse(Console.ReadLine(), out operation))
                {
                    Console.WriteLine("Nieprawidłowe wejście.");
                    continue;
                }

                switch (operation)
                {
                    case 0:
                        MyCalculatorHandler.CloseConnection();
                        break;
                    case 1:
                        MyCalculatorHandler.Addition();
                        break;
                    case 2:
                        MyCalculatorHandler.Subtraction();
                        break;
                    case 3:
                        MyCalculatorHandler.Multiplication();
                        break;
                    case 4:
                        MyCalculatorHandler.Division();
                        break;
                    case 5:
                        MyCalculatorHandler.Modulo();
                        break;
                    case 6:
                        MyCalculatorHandler.HMultiply();
                        break;
                    case 7:
                        MyCalculatorHandler.CountAndMaxPrimesInRangeAsync();
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowe wejście.");
                        break;
                }
            } while (operation != 0);
            Console.ReadKey();
        }

    }
}
