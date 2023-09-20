using Business.Abstract;
using Business.Constance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete;

public class CustomerManager : ICustomerService
{
	 ICustomerDal _customerDal;

	 public CustomerManager(ICustomerDal customerDal)
	 {
		 _customerDal = customerDal;
	 }

	 public IResult Add(Customer customer)
	{
		_customerDal.Add(customer);
		return new SuccessResult(Messages.Null);
	}

	public IResult Delete(Customer customer)
	{
		
		_customerDal.Delete(customer);
		return new SuccessResult(Messages.Null);
	}

	public IResult Update(Customer customer)
	{
		return new SuccessResult(Messages.Null);
	}
}