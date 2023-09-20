using Core.DataAccesss.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfCustomerDal:EfEntityRepositoryBase<Customer ,MultiContext>,ICustomerDal
{
	
}