using NumericSequenceCalculator.App_Code;
using NumericSequenceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web.Mvc;

namespace NumericSequenceCalculator.Controllers
{
    public class HomeController : Controller
    {
        INumericCalculation _NumericCalculation;
        INumericListGenerator _NumericListGenerator;

        string listTitle_AllNumbers = "<h3>All Numbers</h3>";
        string listTitle_OddNumbers = "<h3>Odd Numbers</h3>";
        string listTitle_EvenNumbers = "<h3>Even Numbers</h3>";
        string listTitle_AllNumbersExceptMultipleOf3 = "<h3>All Numbers (Multiples of 3 shown as &lsquo;C&rsquo;)</h3>";
        string listTitle_AllNumbersExceptMultipleOf5 = "<h3>All Numbers (Multiples of 5 shown as &lsquo;E&rsquo;)</h3>";
        string listTitle_AllNumbersExceptMultipleOf3And5 = "<h3>All Numbers (Multiples of 3 &amp; 5 shown as &lsquo;Z&rsquo;)</h3>";
        string listTitle_FibonacciNumbers = "<h3>Fibonacci Numbers</h3>";
        string listSpacer = "<div style=\"height:10px;\"></div>";

        public HomeController(INumericCalculation numericCalculation, INumericListGenerator numericListGenerator)
        {
            _NumericCalculation = numericCalculation;
            _NumericListGenerator = numericListGenerator;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string GenerateLists(InputNumber model)
        {
            if (ModelState.IsValid)
            {
                int number = model.Number;
                int highestNumberAccepted = Convert.ToInt32(ConfigurationManager.AppSettings["HighestNumberAccepted"]);

                if (number > highestNumberAccepted)
                {
                    return "<span class=\"text-danger\">Please enter a number NOT greater than " + highestNumberAccepted + "</span>";
                }

                List<int> allNumbers = new List<int>();
                List<int> oddNumbers = new List<int>();
                List<int> evenNumbers = new List<int>();
                List<string> allNumbers_FlagMultiplesOf3 = new List<string>();
                List<string> allNumbers_FlagMultiplesOf5 = new List<string>();
                List<string> allNumbers_FlagMultiplesOf3And5 = new List<string>();
                List<int> fibonacciNumbers = new List<int>();

                bool isNumberEven;
                bool isNumberMultipleOf3;
                bool isNumberMultipleOf5;

                try
                {
                    for (int i = 1; i <= number; i++)
                    {
                        isNumberEven = _NumericCalculation.IsNumberEven(i);
                        isNumberMultipleOf3 = _NumericCalculation.IsNumberMultipleOf(i, 3);
                        isNumberMultipleOf5 = _NumericCalculation.IsNumberMultipleOf(i, 5);

                        allNumbers.Add(i);

                        if (isNumberEven)
                        {
                            evenNumbers.Add(i);
                        }
                        else
                        {
                            oddNumbers.Add(i);
                        }

                        if (isNumberMultipleOf3)
                        {
                            allNumbers_FlagMultiplesOf3.Add("C");
                        }
                        else
                        {
                            allNumbers_FlagMultiplesOf3.Add(i.ToString());
                        }

                        if (isNumberMultipleOf5)
                        {
                            allNumbers_FlagMultiplesOf5.Add("E");
                        }
                        else
                        {
                            allNumbers_FlagMultiplesOf5.Add(i.ToString());
                        }

                        if (isNumberMultipleOf3 && isNumberMultipleOf5)
                        {
                            allNumbers_FlagMultiplesOf3And5.Add("Z");
                        }
                        else
                        {
                            allNumbers_FlagMultiplesOf3And5.Add(i.ToString());
                        }
                    }

                    fibonacciNumbers = _NumericListGenerator.FibonacciSequence(number);

                    StringBuilder myLists = new StringBuilder();

                    myLists.Append(listTitle_AllNumbers);
                    myLists.Append(String.Join(", ", allNumbers));
                    myLists.Append(listSpacer);
                    
                    myLists.Append(listTitle_OddNumbers);
                    myLists.Append(String.Join(", ", oddNumbers));
                    myLists.Append(listSpacer);
                    
                    myLists.Append(listTitle_EvenNumbers);
                    myLists.Append(String.Join(", ", evenNumbers));
                    myLists.Append(listSpacer);
                    
                    myLists.Append(listTitle_AllNumbersExceptMultipleOf3);
                    myLists.Append(String.Join(", ", allNumbers_FlagMultiplesOf3));
                    myLists.Append(listSpacer);
                    
                    myLists.Append(listTitle_AllNumbersExceptMultipleOf5);
                    myLists.Append(String.Join(", ", allNumbers_FlagMultiplesOf5));
                    myLists.Append(listSpacer);
                    
                    myLists.Append(listTitle_AllNumbersExceptMultipleOf3And5);
                    myLists.Append(String.Join(", ", allNumbers_FlagMultiplesOf3And5));
                    myLists.Append(listSpacer);
                    
                    myLists.Append(listTitle_FibonacciNumbers);
                    myLists.Append(String.Join(", ", fibonacciNumbers));
                    myLists.Append(listSpacer);
                                        
                    return myLists.ToString();
                }
                catch (Exception ex)
                {
                    return "<span class=\"text-danger\">Error processing your request: " + ex.Message + "</span>";
                }
            }

            // If we got this far, something failed, redisplay form
            return "<span class=\"text-danger\">An unhandled exception has occurred. Please retry submitting your number.</span>";
        }
    }
}