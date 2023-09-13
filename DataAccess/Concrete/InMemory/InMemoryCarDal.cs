using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{BrandId=1,CarId=1,ColorId=1,DailyPrice=250,Description="Clio Sedan"},
                new Car{BrandId=1,CarId=2,ColorId=1,DailyPrice=740,Description="Clio Hetcbag"},
                new Car{BrandId=2,CarId=3,ColorId=1,DailyPrice=500,Description="Ford Transit"},
                new Car{BrandId=2,CarId=4,ColorId=2,DailyPrice=360,Description="Ford Sedan"},
                new Car{BrandId=3,CarId=5,ColorId=3,DailyPrice=800,Description="Mercedes Sedan"},
            };

        }

        public void Add(Car cars)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car cars)
        {
            Car arabayiSil = _cars.SingleOrDefault(c => c.CarId == cars.CarId);
            _cars.Remove(arabayiSil);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars.ToList();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void GetById(Car car)
        {
            Car idGetir = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            Console.WriteLine(car.CarId);


        }

		public List<CarDetailDto> GetCarDetails()
		{
			throw new NotImplementedException();
		}

		public void Update(Car car)
        {
            var result = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            result.DailyPrice = car.DailyPrice;
            result.CarId = car.CarId;
            result.BrandId = car.BrandId;
            result.ColorId = car.ColorId;
            result.DailyPrice = car.DailyPrice;
            result.Description = car.Description;

            result.Description = car.Description;
        }




    }
}
