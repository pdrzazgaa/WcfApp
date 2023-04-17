using System;
using System.ServiceModel;
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

            Console.WriteLine("Klient wystartował");
            Uri baseAddress;

            BasicHttpBinding myBinding = new BasicHttpBinding();
            baseAddress = new
                Uri("http://localhost:8080/MyCalculator/endpoint1");

            EndpointAddress endpointAddress = new EndpointAddress(baseAddress);

            ChannelFactory<ICalculator> myCF = new ChannelFactory<ICalculator>(myBinding, endpointAddress);
            ICalculator myClient = myCF.CreateChannel();

            Console.WriteLine("Wywołanie metody Add (dla endpointa1)");
            int result1 = myClient.iAdd(-3, 9);
            Console.WriteLine("Wynik = " + result1);

            CalculatorClient myClient2 = new CalculatorClient("WSHttpBinding_ICalculator");
            Console.WriteLine("Wywołanie metody iMul (dla endpointa2) - ");
            var result2 = myClient2.iMul(-3, 9);
            Console.WriteLine("Wynik = " + result2);

            Console.WriteLine("Wywołanie metody HMultiply ASYNCHRONICZNIE");
            var resultAsync = callHMultiply(-3, 7, myClient2);
            var resultA = resultAsync.Result;
            Console.WriteLine("2... Wynik metody HMultiply Result = "+resultA);

            // Inne operacje

            Console.WriteLine("Naciśnij <ENTER> aby zakończyć");
            Console.WriteLine();
            Console.ReadLine();

            ((IClientChannel)myClient).Close();

            Console.WriteLine("Klient zamknięty - ZAKOŃCZONO");

        }
    }
}
