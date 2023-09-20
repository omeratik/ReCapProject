using Business.Concrete;
using Business.Constance;
using Core.DataAccesss.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.Identity.Client;

namespace ConsoleUI
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//CarTest();

			//GeneralTest();
			//CustomerTest();
			RentalManager rentalManager = new RentalManager(new EfRentalDal());
			var rental1 = new Rental { CarId = 1,RentDate = DateTime.Now};
			var result = rentalManager.Add(rental1);
			Console.WriteLine(result.Message);

		}

		private static void CustomerTest()
		{
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
			Customer customer = new Customer { CustomerId = 1, UserId = 1, CompanyName = "Atik Holding" };
			var result = customerManager.Add(customer);
			Console.WriteLine(result.Message);
		}


		private static void CarTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			var result = carManager.GetCarDetails();
			
			if (result.Success==true)
			{
				foreach (var car in result.Data)
				{
					Console.WriteLine(car.Description + "--" + car.BrandName + "--" + car.ColorName);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}


		  
	}
}