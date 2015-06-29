using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NumericSequenceCalculator.App_Code
{
    public class NumericCalculation : INumericCalculation
    {
        public bool IsNumberEven(int number)
        {
            return number % 2 == 0;
        }

        public bool IsNumberMultipleOf(int number, int multiple)
        {
            return number % multiple == 0;
        }

        public bool IsNumberFibonacci(int number)
        {
            double firstResult = Math.Sqrt((5 * Math.Pow(number, 2)) + 4);
            bool isFibonacci_FirstCalc = (firstResult % 1) == 0;

            double secondResult = Math.Sqrt((5 * Math.Pow(number, 2)) - 4);
            bool isFibonacci_SecondCalc = (secondResult % 1) == 0;

            if (isFibonacci_FirstCalc || isFibonacci_SecondCalc)
            {
                return true;
            }

            return false;
        }
    }
}