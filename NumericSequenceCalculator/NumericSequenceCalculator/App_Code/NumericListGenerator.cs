using System.Collections.Generic;

namespace NumericSequenceCalculator.App_Code
{
    public class NumericListGenerator : INumericListGenerator
    {
        public List<int> FibonacciSequence(int number)
        {
            List<int> fibonacciNumbers = new List<int>();

            int f0 = 0;
            int f1 = 1;
            int fNumber = 0;

            fibonacciNumbers.Add(f0);
            fibonacciNumbers.Add(f1);

            while (number > fNumber)
            {
                fNumber = f0 + f1;
                if (number < fNumber) { break; }

                fibonacciNumbers.Add(fNumber);

                f0 = f1;
                f1 = fNumber;
            }            

            return fibonacciNumbers;
        }
    }
}