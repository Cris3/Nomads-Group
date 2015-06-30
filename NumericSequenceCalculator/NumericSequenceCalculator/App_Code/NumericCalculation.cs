using System;

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
    }
}