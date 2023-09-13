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

		private static void GeneralTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			foreach (var car in carManager.GetCarDetails())
			{
				Console.WriteLine(car.Description + "--" + car.BrandName + "--" + car.ColorName);
			}
		}

		private static void CarTest()
		{
			CarManager carManager = new CarManager(new EfCarDal());
			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine(car.Description);
			}
		}
		
	}
}