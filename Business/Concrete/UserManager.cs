﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Constance;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;

namespace Business.Concrete
{
	public class UserManager : IUserService
	{
		IUserDal _userDal;

		public UserManager(IUserDal userDal)
		{
			_userDal = userDal;
		}

		public List<OperationClaim> GetClaims(User user)
		{
			return _userDal.GetClaims(user);
		}

		public void Add(User user)
		{
			_userDal.Add(user);
		}

		public User GetByMail(string email)
		{
			return _userDal.Get(u => u.Email == email);
		}
	}
}
