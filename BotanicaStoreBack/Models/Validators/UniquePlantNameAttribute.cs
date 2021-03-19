using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Crosserator.Models.Validators
{
	public class UniquePlantNameAttribute : ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			if (value != null)
			{
				int plantId = (int)validationContext.ObjectInstance.GetType().GetProperty("PlantId").GetValue(validationContext.ObjectInstance, null);
				int userId = (int)validationContext.ObjectInstance.GetType().GetProperty("UserId").GetValue(validationContext.ObjectInstance, null);
				string newPlantName = (string)value;

				using (var db = new Crosserator.Repositories.PlantDb())
					if (!db.IsUniquePlantName(plantId, userId, newPlantName))
						return new ValidationResult("Plant name is already used.");
			}

			return ValidationResult.Success;
		}

	}
}