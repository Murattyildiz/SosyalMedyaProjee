using Core.Service;
using Core.Entities.Concrete;
using Core.Utulities.Result.Abstract;
using Entities.DTOs;


namespace Business.Abstract
{
    public interface IUserService:IServiceRepository<User>
    {
       IDataResult<List<OperationClaim>> GetClaims (User user);

        IDataResult<User> GetUserByMail(string email);

        IResult UpdateByDto (UserDto userDto);

        IDataResult<List<UserDto>> GetAllDto();

        IDataResult<UserDto> GetUserDtoById(int userId);

        IResult Delete(int userId);

    }
}
