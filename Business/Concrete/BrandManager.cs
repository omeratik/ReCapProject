using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Constance;
using Core.Utilities.Results;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public IDataResult<List<Brand>> GetAll()
		{
			return new SuccessDataResult<List<Brand>> (_brandDal.GetAll(),Messages.VehicleListed);
		}

		public IDataResult<Brand> GetById(int brandId)
		{
			return new SuccessDataResult<Brand> (_brandDal.Get(b => b.BrandId == brandId));
		}
	}
}
