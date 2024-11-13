using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utulities.Result.Abstract;
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
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            throw new NotImplementedException();
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string passowrd)
        {
            throw new NotImplementedException();
        }

        public IResult UserExist(string email)
        {
            throw new NotImplementedException();
        }
    }
}
