using NumericSequenceCalculator.App_Code;
using NumericSequenceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NumericSequenceCalculator.Controllers
{
    public class HomeController : Controller
    {
        INumericCalculation _NumericCalculation;

        public HomeController(INumericCalculation numericCalculation)
        {
            _NumericCalculation = numericCalculation;
        }

        public ActionResult Index()
        {
            Session["AllNumbers"] = null;
            Session["OddNumbers"] = null;
            Session["EvenNumbers"] = null;
            Session["AllNumbersExceptMultipleOf3"] = null;
            Session["AllNumbersExceptMultipleOf5"] = null;
            Session["AllNumbersExceptMultipleOf3And5"] = null;
            Session["FibonacciNumbers"] = null;

            ViewBag.ErrorMSG = "";
            ViewBag.AllNumbers = "";
            ViewBag.OddNumbers = "";
            ViewBag.EvenNumbers = "";
            ViewBag.AllNumbersExceptMultipleOf3 = "";
            ViewBag.AllNumbersExceptMultipleOf5 = "";
            ViewBag.AllNumbersExceptMultipleOf3And5 = "";
            ViewBag.FibonacciNumbers = "";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(InputNumber model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.ErrorMSG = "";

                int number = model.Number;

                List<int> allNumbers = new List<int>();
                List<int> oddNumbers = new List<int>();
                List<int> evenNumbers = new List<int>();
                List<string> allNumbersExceptMultipleOf3 = new List<string>();
                List<string> allNumbersExceptMultipleOf5 = new List<string>();
                List<string> allNumbersExceptMultipleOf3And5 = new List<string>();
                List<int> fibonacciNumbers = new List<int>();

                if (Session["AllNumbers"] != null)
                {
                    allNumbers = (List<int>)Session["AllNumbers"];
                }

                if (Session["OddNumbers"] != null)
                {
                    oddNumbers = (List<int>)Session["OddNumbers"];
                }

                if (Session["EvenNumbers"] != null)
                {
                    evenNumbers = (List<int>)Session["EvenNumbers"];
                }

                if (Session["AllNumbersExceptMultipleOf3"] != null)
                {
                    allNumbersExceptMultipleOf3 = (List<string>)Session["AllNumbersExceptMultipleOf3"];
                }

                if (Session["AllNumbersExceptMultipleOf5"] != null)
                {
                    allNumbersExceptMultipleOf5 = (List<string>)Session["AllNumbersExceptMultipleOf5"];
                }

                if (Session["AllNumbersExceptMultipleOf3And5"] != null)
                {
                    allNumbersExceptMultipleOf3And5 = (List<string>)Session["AllNumbersExceptMultipleOf3And5"];
                }

                if (Session["FibonacciNumbers"] != null)
                {
                    fibonacciNumbers = (List<int>)Session["FibonacciNumbers"];
                }

                foreach (int oldNumber in allNumbers)
                {
                    if (oldNumber == number)
                    {
                        ViewBag.ErrorMSG = "You have already entered this number: " + number;
                        goto Label_DisplayLists;
                        //return View(model);
                    }
                }

                try
                {
                    bool isNumberEven = _NumericCalculation.IsNumberEven(number);
                    bool isNumberMultipleOf3 = _NumericCalculation.IsNumberMultipleOf(number, 3);
                    bool isNumberMultipleOf5 = _NumericCalculation.IsNumberMultipleOf(number, 5);
                    bool isNumberFibonacci = _NumericCalculation.IsNumberFibonacci(number);

                    allNumbers.Add(number);

                    if (isNumberEven)
                    {
                        evenNumbers.Add(number);
                    }
                    else
                    {
                        oddNumbers.Add(number);
                    }

                    if (isNumberMultipleOf3)
                    {
                        allNumbersExceptMultipleOf3.Add("C");
                    }
                    else
                    {
                        allNumbersExceptMultipleOf3.Add(number.ToString());
                    }

                    if (isNumberMultipleOf5)
                    {
                        allNumbersExceptMultipleOf5.Add("E");
                    }
                    else
                    {
                        allNumbersExceptMultipleOf5.Add(number.ToString());
                    }

                    if (isNumberMultipleOf3 && isNumberMultipleOf5)
                    {
                        allNumbersExceptMultipleOf3And5.Add("Z");
                    }
                    else
                    {
                        allNumbersExceptMultipleOf3And5.Add(number.ToString());
                    }

                    if (isNumberFibonacci) { fibonacciNumbers.Add(number); }

                    Session["AllNumbers"] = allNumbers;
                    Session["OddNumbers"] = oddNumbers;
                    Session["EvenNumbers"] = evenNumbers;
                    Session["AllNumbersExceptMultipleOf3"] = allNumbersExceptMultipleOf3;
                    Session["AllNumbersExceptMultipleOf5"] = allNumbersExceptMultipleOf5;
                    Session["AllNumbersExceptMultipleOf3And5"] = allNumbersExceptMultipleOf3And5;
                    Session["FibonacciNumbers"] = fibonacciNumbers;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Error processing your request: " + ex.Message);
                    return View(model);
                }

            Label_DisplayLists:
                ViewBag.AllNumbers = String.Join(", ", allNumbers);
                ViewBag.OddNumbers = String.Join(", ", oddNumbers);
                ViewBag.EvenNumbers = String.Join(", ", evenNumbers);
                ViewBag.AllNumbersExceptMultipleOf3 = String.Join(", ", allNumbersExceptMultipleOf3);
                ViewBag.AllNumbersExceptMultipleOf5 = String.Join(", ", allNumbersExceptMultipleOf5);
                ViewBag.AllNumbersExceptMultipleOf3And5 = String.Join(", ", allNumbersExceptMultipleOf3And5);
                ViewBag.FibonacciNumbers = String.Join(", ", fibonacciNumbers);

                return View(model);
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "An unhandled exception has occurred. Please retry submitting your number.");
            return View(model);
        }
    }
}