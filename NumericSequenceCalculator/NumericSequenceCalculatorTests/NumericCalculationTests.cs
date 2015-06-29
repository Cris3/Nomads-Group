using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericSequenceCalculator.App_Code;
using NumericSequenceCalculator.Models;

namespace NumericSequenceCalculator.Tests
{
    [TestClass()]
    public class NumericCalculationTests
    {
        public NumericCalculationTests()
        {
        }

        NumericCalculation numericCalculation = new NumericCalculation();
        InputNumber inputNumber = new InputNumber();

        [TestMethod()]
        public void IsNumberOddTest() //S3.1.2: Test if number is odd
        {
            InputNumber inputNumber = new InputNumber()
            {
                Number = 1
            };

            bool isNumberEven = numericCalculation.IsNumberEven(inputNumber.Number);

            Assert.IsTrue(!isNumberEven);
        }

        [TestMethod()]
        public void IsNumberEvenTest() //S3.1.3: Test if number is even
        {
            InputNumber inputNumber = new InputNumber()
            {
                Number = 2
            };

            bool isNumberEven = numericCalculation.IsNumberEven(inputNumber.Number);

            Assert.IsTrue(isNumberEven);
        }

        [TestMethod()]
        public void IsNumberMultipleOf3Test() //S3.1.4.1: Test if number is multiple of 3
        {
            InputNumber inputNumber = new InputNumber()
            {
                Number = 9
            };

            bool isNumberMultipleOf3 = numericCalculation.IsNumberMultipleOf(inputNumber.Number, 3);

            Assert.IsTrue(isNumberMultipleOf3);
        }

        [TestMethod()]
        public void IsNumberMultipleOf5Test() //S3.1.4.2: Test if number is multiple of 5
        {
            InputNumber inputNumber = new InputNumber()
            {
                Number = 10
            };

            bool isNumberMultipleOf5 = numericCalculation.IsNumberMultipleOf(inputNumber.Number, 5);

            Assert.IsTrue(isNumberMultipleOf5);
        }

        [TestMethod()]
        public void IsNumberMultipleOf3And5Test() //S3.1.4.3: Test if number is multiple of 3 and 5
        {
            InputNumber inputNumber = new InputNumber()
            {
                Number = 15
            };

            bool isNumberMultipleOf3 = numericCalculation.IsNumberMultipleOf(inputNumber.Number, 3);
            bool isNumberMultipleOf5 = numericCalculation.IsNumberMultipleOf(inputNumber.Number, 5);
            bool isNumberMultipleOf3And5 = false;

            if (isNumberMultipleOf3 && isNumberMultipleOf5)
            {
                isNumberMultipleOf3And5 = true;
            }

            Assert.IsTrue(isNumberMultipleOf3And5);
        }

        [TestMethod()]
        public void IsNumberFibonacciTest() //S3.1.5: Test if number is fibonacci
        {
            InputNumber inputNumber = new InputNumber()
            {
                Number = 34
            };

            bool isNumberFibonacci = numericCalculation.IsNumberFibonacci(inputNumber.Number);

            Assert.IsTrue(isNumberFibonacci);
        }
    }
}
