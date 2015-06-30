using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NumericSequenceCalculator.Models
{
    public class InputNumber
    {
        [Required(ErrorMessage = "Please enter a number")]
        [RegularExpression("^[1-9]+[0-9]*$", ErrorMessage = "Please enter a positive integer number")]
        [Display(Name = "Number")]
        public int Number { get; set; }
    }
}