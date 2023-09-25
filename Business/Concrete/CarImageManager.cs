using System.Runtime.InteropServices.JavaScript;
using Business.Abstract;
using Business.Constants;
using Core.Helpers.FileHelper;
using Core.Utilities.Business.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete;

public class CarImageManager : ICarImageService
{
	private ICarImageDal _carImageDal;
	IFileHelper _fileHelper;
	public CarImageManager(ICarImageDal carImageDal, IFileHelper fileHelper)
	{
		_carImageDal = carImageDal;
		_fileHelper = fileHelper;
	}

	public IResult Add(IFormFile file, CarImage carImage)

	{
		IResult result = BusinessRules.Run(CheckCarImageLimiter(carImage.CarId));
		if (result != null)
		{
			return result;
		}

		carImage.ImagePath = _fileHelper.Upload(file, PathConstans.ImagesPath);
		carImage.Date= DateTime.Now;
		_carImageDal.Add(carImage);
		return new SuccessResult("Resiminiz yüklendi");


	}

	public IResult Delete(CarImage carImage)
	{
		_fileHelper.Delete(PathConstans.ImagesPath+carImage.ImagePath);
		_carImageDal.Delete(carImage);
		return new SuccessResult();
	}

	public IDataResult<List<CarImage>> GetAll()
	{
		return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
	}

	public IDataResult<List<CarImage>> GetByCarId(int carId)
	{
		var result = BusinessRules.Run(CheckCarPhoto(carId));
		if (result !=null)
		{
			return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data);
		}

		return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
	}

	public IDataResult<CarImage> GetByImageId(int imageId)
	{
		return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
	}

	public IResult Update(IFormFile file, CarImage carImage)
	{
		carImage.ImagePath= _fileHelper.Upload(file,PathConstans.ImagesPath+carImage.ImagePath);
		_carImageDal.Update(carImage);
		return new SuccessResult();
	}

	private IDataResult<List<CarImage>> GetDefaultImage(int carId)
	{
		List<CarImage> carImages = new List<CarImage>();
		carImages.Add(new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = "Default Image" });
		return new SuccessDataResult<List<CarImage>>(carImages);
	}
	private IResult CheckCarPhoto(int carId)
	{
		var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
		if (result>0)
		{
			return new SuccessResult();
		}

		return new ErrorResult();
	}
	private IResult CheckCarImageLimiter(int carId)
	{
		var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
		if (result>=5)
		{
			return new ErrorResult();
		}

		return new SuccessResult();
	}

}