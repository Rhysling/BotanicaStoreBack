using System;
using System.ComponentModel.DataAnnotations;

namespace Crosserator.Models.Validators
{
	public class MustBeGreaterthanZeroAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				if (value.GetType() != 1.GetType())
					return new ValidationResult(validationContext.DisplayName + " is not a number.");

				int i = (int)value;

				if (i == 0)
					return new ValidationResult(validationContext.DisplayName + " is zero.");

				if (i < 0)
					return new ValidationResult(validationContext.DisplayName + " is less than zero.");
			}

			return ValidationResult.Success;
		}
	}
}