using System;
using System.ComponentModel.DataAnnotations;

namespace Crosserator.Models.Validators
{
	public class CurrentDateTimeAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				DateTime d;
				if (!DateTime.TryParse((string)value, out d))
					return new ValidationResult(validationContext.DisplayName + " is not a date.");

				if ((d < new DateTime(1910, 1, 1)) || (d > new DateTime(2100, 1, 1)))
					return new ValidationResult(validationContext.DisplayName + " is out of range.");
			}

			return ValidationResult.Success;
		}

	}
}