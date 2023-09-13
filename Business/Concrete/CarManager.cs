using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal cardal)
		{
			_carDal = cardal;
		}

		public List<Car> GetAll()
		{
			return	_carDal.GetAll();
		}

		public List<Car> GetByAllBrandId(int id)
		{
			return _carDal.GetAll(c => c.BrandId == id && c.DailyPrice > 0 && c.Description.Length > 2);
		}

		public List<Car> GetByColorName(int id)
		{
			return _carDal.GetAll(c => c.ColorId == id);
		}

		public List<CarDetailDto> GetCarDetails()
		{
			return _carDal.GetCarDetails();
		}
	}
}
