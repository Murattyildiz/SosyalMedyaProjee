using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConncerns.Logging.Log4Net.Logger;
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

        //public void DeleteTopicDaily()
        //{
        //    var allTopic = _konuDal.GetAll(x => x.Status == true);
        //    if (allTopic != null)
        //    {
        //        foreach (var konu in allKonu)
        //        {
        //            Konu updatedTopic = new Konu();
        //            {
        //                Id = konu.Id,
        //                TopicTitle = Konu.,
        //                Status = false
        //            };
        //            _topicDal.Update(updatedTopic);
        //        }
        //    }


         [LogAspect(typeof(FileLogger))]
        //[ValidationAspect(typeof(KonuValidator))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IKonuService.Get")]
        public IResult Add(Konu entity)
        {
          _konuDal.Add(entity);
           return new SuccessResult(Messages.Konu_Add);
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("IKonuService.Get")]
        public IResult Delete(int id)
        {
            var deleteKonu = _konuDal.Get(x => x.Id == id);
            if (deleteKonu != null)
            {
                _konuDal.Delete(deleteKonu);
                return new SuccessResult(Messages.Konu_Delete);
            }
            return new ErrorResult(Messages.KonuNotFound);
        }
        [CacheAspects(2)]
        public IDataResult<List<Konu>> GetAll()
        {
            return new SuccessDataResult<List<Konu>>(_konuDal.GetAll(), Messages.Konus_List);
        }

        public IDataResult<Konu> GetEntityById(int id)
        {
           return new SuccessDataResult<Konu>(_konuDal.Get(x=>x.Id==id),Messages.Konu_List);
        }
        [LogAspect(typeof(FileLogger))]
        //[ValidationAspect(typeof(TopicCValidator))]
        [SecuredOperation("admin")]
        [CacheRemoveAspect("ITopicService.Get")]
        public IResult Update(Konu entity)
        {
            _konuDal.Update(entity);
            return new SuccessResult(Messages.Konu_Update);
        }
    }
}
