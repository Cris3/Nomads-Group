
namespace NumericSequenceCalculator.App_Code
{
    public interface INumericCalculation
    {
        bool IsNumberEven(int number);
        bool IsNumberMultipleOf(int number, int multiple);
        bool IsNumberFibonacci(int number);
    }
}
