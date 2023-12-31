﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constance;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal cardal)
		{
			_carDal = cardal;
		}

		[ValidatorAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		public Result Add(Car car)
		{
			
			_carDal.Add(car);
			return new SuccessResult(Messages.VehicleAdd);

		}
		[TransactionScopeAspect]
		public IResult AddTransactionalTest(Car car)
		{
			_carDal.Add(car);
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}

		public Result Delete(Car car)
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.Null);
		}

		[SecuredOperation("Car.List,user")]
		[CacheAspect()]
		public IDataResult<List<Car>> GetAll()
		{
			if (DateTime.Now.Hour==13)
			{
				return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
			}

			return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.VehicleListed);
		}

		public IDataResult<List<Car>> GetByAllBrandId(int id)
		{
			return new SuccessDataResult<List<Car>> (_carDal.GetAll(c => c.BrandId == id && c.DailyPrice > 0 && c.Description.Length > 2));
		}

		public IDataResult<List<Car>> GetByColorName(int id)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
		}

		public IDataResult<Car> GetById(int carId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c=> c.CarId== carId));
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
		}

		public Result Update(Car car)
		{
			throw new NotImplementedException();
		}
	}
}
