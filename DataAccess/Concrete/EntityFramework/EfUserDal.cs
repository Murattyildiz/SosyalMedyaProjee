using Core.DataAccess;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal:EfEntityRepository<User,SosyalMedyaContext>,IUserDal
    {

    }
}
