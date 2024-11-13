using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utulities.Result.Abstract;
using Core.Utulities.Result.Concrete;
using Core.Utulities.Security.Hashing;
using Core.Utulities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(ITokenHelper tokenHelper, IUserService userService = null)
        {
            _tokenHelper = tokenHelper;
            _userService = userService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetUserByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErroDataResult 
            }

          

         
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string passowrd)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(passowrd, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Gender = userForRegisterDto.Gender,
                PhoneNumber = userForRegisterDto.PhoneNumber,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        public IResult UserExist(string email)
        {
            throw new NotImplementedException();
        }
    }
}
