using System.Collections.Generic;

namespace NumericSequenceCalculator.App_Code
{
    public interface INumericListGenerator
    {
        List<int> FibonacciSequence(int number);
    }
}
