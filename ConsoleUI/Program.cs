using Business.Concrete;
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