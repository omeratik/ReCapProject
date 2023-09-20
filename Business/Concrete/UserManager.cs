﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constance;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public IResult Add(User user)
		{
			_userDal.Add(user);
			return new SuccessResult(Messages.Null);
		}

		public IResult Delete(User user)
		{
			_userDal.Delete(user);
			return new SuccessResult(Messages.Null);
		}

		public IResult Update(User user)
		{
			_userDal.Update(user);
			return new SuccessResult(Messages.Null);
		}
	}
}
