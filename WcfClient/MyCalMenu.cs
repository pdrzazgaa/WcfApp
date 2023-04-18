using System;
using System.ServiceModel;
using WcfClient.ServiceReference1;

namespace WcfClient
{

    public class MyCalMenu
    {
        static CalculatorClient _client1 = new CalculatorClient("BasicHttpBinding_ICalculator");
        static CalculatorClient _client2 = new CalculatorClient("WSHttpBinding_ICalculator");

        static public void Close()
        {
            Console.WriteLine("Pa pa! :(");
            _client1.Close();
            _client2.Close();
        }
        static private int GetNumberFromUser()
        {
            int number;
            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Niewłaściwe wejście.");
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
                int result = _client1.iAdd(n1, n2);
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
                int result = _client1.iSub(n1, n2);
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
                int result = _client1.iMul(n1, n2);
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
                int result = _client1.iDiv(n1, n2);
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
                int result = _client1.iMod(n1, n2);
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
                var result = await _client2.HMultiplyAsync(n1, n2);
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
                var result = await _client2.CountAndMaxPrimesInRangeAsync(l1, l2);
                Console.WriteLine($"{result.Item1} liczb pierwszych.");
                Console.WriteLine($"Największa liczba pierwsza: {result.Item2}");
            }
            catch (FaultException<ArgumentException> ex)
            {
                Console.WriteLine(ex.Detail.Message);
            }
        }
    }

}
