using System;
using System.ServiceModel;
using System.Threading;

namespace WcfService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class MyCalculator : ICalculator
    {
        public int iAdd(int val1, int val2)
        {
            Console.WriteLine($"Wywołano funkcję iAdd({val1}, {val2})");
            try
            {
                checked
                {
                    int result = val1 + val2;
                    Console.WriteLine($"Otrzymany wynik z operacji iAdd: {result}");
                    return result;
                }
            }
            catch (OverflowException ex)
            {
                throw new FaultException<OverflowException>(ex, new FaultReason($"Przepelnienie podczas wykonywania operacji dla liczb {val1} i {val2}"));
            }
        }
        public int iSub(int val1, int val2)
        {
            Console.WriteLine($"Wywołano funkcję iSub({val1}, {val2})");
            try
            {
                checked
                {
                    int result = val1 - val2;
                    Console.WriteLine($"Otrzymany wynik z operacji iSub: {result}");
                    return result;
                }
            }
            catch (OverflowException ex)
            {
                throw new FaultException<OverflowException>(ex, new FaultReason($"Przepelnienie podczas wykonywania operacji dla liczb {val1} i {val2}"));
            }
        }
        public int iMul(int val1, int val2)
        {
            Console.WriteLine($"Wywołano funkcję iMul({val1}, {val2})");

            try
            {
                checked
                {
                    int result = val1 * val2;
                    Console.WriteLine($"Otrzymany wynik z operacji iMul: {result}");
                    return result;
                }
            }
            catch (OverflowException ex)
            {
                throw new FaultException<OverflowException>(ex, new FaultReason($"Przepelnienie podczas wykonywania operacji dla liczb {val1} i {val2}"));
            }

        }
        public int iDiv(int val1, int val2)
        {
            Console.WriteLine($"Wywołano funkcję iDiv({val1}, {val2})");
            try
            {
                checked
                {
                    int result = val1 / val2;
                    Console.WriteLine($"Otrzymany wynik z operacji iDiv:{result}");
                    return result;
                }
            }
            catch (DivideByZeroException ex)
            {
                throw new FaultException<DivideByZeroException>(ex, new FaultReason("Nie można dzielić przez 0"));
            }
            catch (OverflowException ex)
            {
                throw new FaultException<OverflowException>(ex, new FaultReason($"Przepelnienie podczas wykonywania operacji dla liczb {val1} i  {val2}"));
            }
        }
        public int iMod(int val1, int val2)
        {
            Console.WriteLine($"Wywołano funkcję iMod({val1}, {val2})");
            try
            {
                int result = val1 % val2;
                Console.WriteLine($"Otrzymany wynik z operacji iMod {result}");
                return result;
            }
            catch (DivideByZeroException ex)
            {
                throw new FaultException<DivideByZeroException>(ex, new FaultReason("Nie można dzielić przez 0"));
            }
            catch (OverflowException ex)
            {
                throw new FaultException<OverflowException>(ex, new FaultReason($"Przepelnienie podczas wykonywania operacji dla liczb {val1} i {val2}"));
            }
        }

        public int HMultiply(int val1, int val2)
        {
            Console.WriteLine($"Wywołano funkcję iMul({val1}, {val2})");
            Thread.Sleep(5000);

            try
            {
                checked
                {
                    int result = val1 * val2;
                    Console.WriteLine($"Otrzymany wynik z operacji iMul: {result}");
                    return result;
                }
            }
            catch (OverflowException ex)
            {
                throw new FaultException<OverflowException>(ex, new FaultReason($"Przepelnienie podczas wykonywania operacji dla liczb {val1} i {val2}"));
            }
        }

        public (int, int) CountAndMaxPrimesInRange(int val1, int val2)
        {

            Console.WriteLine($"Wywołano funkcję dla liczb pierwszych w przedziale ({val1}, {val2})");
            var prime = new bool[val2 + 1];
            for (var i = 0; i < prime.Length; i++)
                prime[i] = true;

            prime[0] = false;
            prime[1] = false;

            for (var p = 2; p * p <= val2; p++)
            {
                if (prime[p])
                {
                    for (var i = p * p; i <= val2; i += p)
                        prime[i] = false;
                }
            }

            var count = 0;
            var max = -1;
            for (var p = val1; p <= val2; p++)
            {
                if (prime[p])
                {
                    count++;
                    max = p;
                }
            }
            Console.WriteLine($"Liczba liczb pierwszych: {count}");
            Console.WriteLine($"Największa liczba pierwsza: {max}");
            return (count, max);
        }
    }
}
