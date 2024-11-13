
using Core.Entities.Concrete;
using Core.Utulities.Result.Abstract;
using Core.Utulities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string passowrd);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
     

 
    }
}
