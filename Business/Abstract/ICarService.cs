using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
	public interface ICarService
	{
		IDataResult<List<Car>> GetAll();
		IDataResult<List<Car>> GetByAllBrandId(int id);
		IDataResult<List<Car>> GetByColorName(int id );
		IDataResult<List<CarDetailDto>> GetCarDetails();
		Result Add(Car car);
		Result Update(Car car);
		Result Delete(Car car);
		

	}
}
