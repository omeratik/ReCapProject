using Core.Entities;
using Core.Entities.Concrete;

namespace DataAccess.Abstract;

public interface IUserDal:IEntityRespository<User>
{
	List<OperationClaim> GetClaims(User user);
}