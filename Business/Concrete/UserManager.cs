﻿using AutoMapper;
using Business.Abstract;
using Business.Request.User;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IMapper _mapper;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public void Register(RegisterRequest registerRequest)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(registerRequest.Password,out passwordHash, out passwordSalt);

            User user = new() {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Email = registerRequest.Email,
                Approved = false,
                
            };

            _userDal.Add(user);

        }
    }
}
