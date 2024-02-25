using AutoMapper;
using Business.Abstract;
using Business.Request.User;
using Core.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
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
        private readonly ITokenHelper _tokenHelper;

        public UserManager(IUserDal userDal, IMapper mapper, ITokenHelper tokenHelper)
        {
            _userDal = userDal;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
        }

        public AccessToken Login(LoginRequest request)
        {
           var user = _userDal.Get(p=>p.Email == request.Email);

            bool passwordCorrect = HashingHelper.VerifyPassword(request.Password,user.PasswordHash,user.PasswordSalt);

            if(!passwordCorrect)
            {
                throw new Exception("Password Incorrect");
            }

            return _tokenHelper.CreateToken(user);
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
