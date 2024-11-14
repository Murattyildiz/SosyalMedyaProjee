using Business.Abstract;
using Business.Constans;
using Core.Utulities.Result.Abstract;
using Core.Utulities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class KonuManager : IKonuService
    {
        IKonuDal _konuDal;

        public KonuManager(IKonuDal konuDal)
        {
            _konuDal = konuDal;
        }

        public IResult Add(Konu entity)
        {
          _konuDal.Add(entity);
           return new SuccessResult(Messages.Konu_Add);
        }

        public IResult Delete(Konu entity)
        {
            _konuDal.Delete(entity);
            return new SuccessResult(Messages.Konu_Delete);
        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Konu>> GetAll()
        {
            return new SuccessDataResult<List<Konu>>(_konuDal.GetAll(), Messages.Konus_List);
        }

        public IDataResult<Konu> GetById(int id)
        {
           return new SuccessDataResult<Konu>(_konuDal.Get(x=>x.Id==id),Messages.Konu_List);
        }

        public IResult Update(Konu entity)
        {
            _konuDal.Update(entity);
            return new SuccessResult(Messages.Konu_Update);
        }
    }
}
