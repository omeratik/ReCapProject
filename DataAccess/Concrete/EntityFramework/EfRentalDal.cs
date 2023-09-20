using Core.DataAccesss.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework;

public class EfRentalDal:EfEntityRepositoryBase<Rental,MultiContext>,IRentalDal
{

}