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
            catch (OverflowException)
            {
                throw new OverflowException($"Przepelnienie podczas wykonywania operacji dla liczb {val1},{val2}");
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
            catch (OverflowException)
            {
                throw new OverflowException($"Przepelnienie podczas wykonywania operacji dla liczb {val1},{val2}");
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
            catch (OverflowException)
            {
                throw new OverflowException($"Przepelnienie podczas wykonywania operacji dla liczb {val1},{val2}");
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
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("Nie można dzielić przez 0");
            }
            catch (OverflowException)
            {
                throw new OverflowException($"Przepelnienie podczas wykonywania operacji dla liczb {val1},{val2}");
            }
        }
        public int iMod(int val1, int val2)
        {
            Console.WriteLine($"Wywołano funkcję iMod({val1}, {val2})");
            if (val2 == 0)
            {
                throw new DivideByZeroException("Nie można dzielić przez 0");
            }
            try
            {
                int result = val1 % val2;
                Console.WriteLine($"Otrzymany wynik z operacji iMod {result}");
                return result;
            }
            catch (OverflowException)
            {
                throw new OverflowException($"Przepelnienie podczas wykonywania operacji dla liczb {val1},{val2}");
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
            catch (OverflowException)
            {
                throw new OverflowException($"Przepelnienie podczas wykonywania operacji dla liczb {val1},{val2}");
            }
        }
    }
}
