using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
	public class CarValidator:AbstractValidator<Car>
	{
		public CarValidator()
		{
			RuleFor(c => c.CarName).MinimumLength(1);
			//...
			RuleFor(c => c.CarName).Must(StartWithA).WithMessage("Araba ismi B ile başlamalı");

		}

		private bool StartWithA(string arg)
		{
			return arg.StartsWith("B");
		}
	}
	//Kendim bir kural eklemek istersem örnek kural.
	
}
