using System;
using System.ServiceModel;
using WcfClient.ServiceReference1;

namespace WcfClient
{

    public class MalCalMenu
    {
        static CalculatorClient _client = new CalculatorClient("WSHttpBinding_ICalculator");

        static public void Close()
        {
            Console.WriteLine("Goodbye!");
            _client.Close();
        }
        static private int GetNumberFromUser()
        {
            int number;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input.");
                return GetNumberFromUser();
            }
            return number;
        }

        static public void Add()
        {
            Console.WriteLine("Podaj pierwszą liczbę:");
            int n1 = GetNumberFromUser();
            Console.WriteLine("Podaj drugą liczbę:");
            int n2 = GetNumberFromUser();

            try
            {
                int result = _client.iAdd(n1, n2);
                Console.WriteLine($"{n1} + {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static public void Sub()
        {
            Console.WriteLine("Podaj pierwszą liczbę:");
            int n1 = GetNumberFromUser();
            Console.WriteLine("Podaj drugą liczbę:");
            int n2 = GetNumberFromUser();

            try
            {
                int result = _client.iSub(n1, n2);
                Console.WriteLine($"{n1} - {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static public void Mul()
        {
            Console.WriteLine("Podaj pierwszą liczbę:");
            int n1 = GetNumberFromUser();
            Console.WriteLine("Podaj drugą liczbę:");
            int n2 = GetNumberFromUser();

            try
            {
                int result = _client.iMul(n1, n2);
                Console.WriteLine($"{n1} * {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static public void Div()
        {
            Console.WriteLine("Podaj pierwszą liczbę:");
            int n1 = GetNumberFromUser();
            Console.WriteLine("Podaj drugą liczbę:");
            int n2 = GetNumberFromUser();

            try
            {
                int result = _client.iDiv(n1, n2);
                Console.WriteLine($"{n1} / {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static public void Mod()
        {
            Console.WriteLine("Podaj pierwszą liczbę:");
            int n1 = GetNumberFromUser();
            Console.WriteLine("Podaj drugą liczbę:");
            int n2 = GetNumberFromUser();

            try
            {
                int result = _client.iMod(n1, n2);
                Console.WriteLine($"{n1} % {n2} = {result}");
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static public async void HMul()
        {
            Console.WriteLine("Podaj pierwszą liczbę:");
            int n1 = GetNumberFromUser();
            Console.WriteLine("Podaj drugą liczbę:");
            int n2 = GetNumberFromUser();

            try
            {
                var result = await _client.HMultiplyAsync(n1, n2);
                Console.WriteLine($"HMultiply asynchronicznie: {n1} * {n2} = {result}"); ;
            }
            catch (FaultException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static public async void PrimeNumbersInRange()
        {
            Console.WriteLine("Podaj pierwszą liczbę:");
            int l1 = GetNumberFromUser();
            Console.WriteLine("Podaj drugą liczbę:");
            int l2 = GetNumberFromUser();

            try
            {
                var result = await _client.CountAndMaxPrimesInRangeAsync(l1, l2);
                Console.WriteLine($"{result.Item1} liczb pierwszy.");
                Console.WriteLine($"Największa liczba pierwsza: {result.Item2}");
            }
            catch (FaultException<ArgumentException> ex)
            {
                Console.WriteLine(ex.Detail.Message);
            }
        }
    }

}
