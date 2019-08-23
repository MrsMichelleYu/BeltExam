using System.ComponentModel.DataAnnotations;
using System;

namespace BeltExam.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        public FutureDateAttribute()
        {

        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }
            var dt = (DateTime)value;
            if (dt > DateTime.Now)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Date must be in the future");
        }
    }
}