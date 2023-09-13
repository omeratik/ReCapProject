using Core.DataAccesss.EntityFramework;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;




namespace DataAccess.Concrete.EntityFramework
{
	public class EfColorDal : EfEntityRepositoryBase<Color, MultiContext>,IColorDal
	{
		
	}
}
