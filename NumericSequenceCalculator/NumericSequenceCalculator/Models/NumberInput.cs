using System;
using System.ComponentModel.DataAnnotations;

namespace NumericSequenceCalculator.Models
{
    public class InputNumber
    {
        [Required(ErrorMessage = "Please enter a number")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter an positive integer number")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Please enter a positive integer number")]
        [Display(Name = "Number")]
        public int Number { get; set; }
    }
}