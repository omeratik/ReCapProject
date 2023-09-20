using Business.Abstract;
using Business.Constance;
using Core.DataAccesss.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete;

public class RentalManager : IRentalService
{
	 IRentalDal _rentalDal;

	 public RentalManager(IRentalDal rentalDal)
	 {
		 _rentalDal = rentalDal;
	 }

	public IResult Add(Rental rental)
	{
		if (rental.RentDate !=null)
		{
			_rentalDal.Add(rental);
			return new SuccessResult(Messages.Null);
		}
		else
		{
			return new SuccessResult(Messages.Null);
		}
	}
}