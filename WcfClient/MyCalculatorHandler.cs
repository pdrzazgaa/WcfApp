using System;
using System.ServiceModel;
using WcfClient.ServiceReference1;

namespace WcfClient
{

    public class MyCalculatorHandler
    {
        static CalculatorClient _client = new CalculatorClient("WSHttpBinding_ICalculator");

        static public void CloseConnection()
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

        static public void Addition()
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

        static public void Subtraction()
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

        static public void Multiplication()
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
        static public void Division()
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
        static public void Modulo()
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
        static public async void HMultiply()
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

        static public async void CountAndMaxPrimesInRangeAsync()
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
