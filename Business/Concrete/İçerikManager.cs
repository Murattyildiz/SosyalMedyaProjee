using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constans;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConncerns.Logging.Log4Net.Logger;
using Core.Entities.Concrete;
using Core.Utulities.Result.Abstract;
using Core.Utulities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class İçerikManager : IİçerikService
    {
        private readonly IİçerikDal _içerikDal;
        private readonly ICommentService _commentService;

        public İçerikManager(IİçerikDal içerikDal, ICommentService commentService)
        {
            _içerikDal = içerikDal;
            _commentService = commentService;
        }
        [LogAspect(typeof(FileLogger))]
        //[ValidationAspect(typeof(İçerikValidator))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IİçerikService.Get")]
        public IResult Add(İçerik entity)
        {
            _içerikDal.Add(entity);
            return new SuccessResult(Messages.İçerik_Add);
        }
        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IİçerikService.Get")]
        public IResult Delete(int id)
        {
            var deleteİçerik = _içerikDal.Get(x => x.Id == id);
            if (deleteİçerik != null)
            {
                var deledetComment = _commentService.GetbyİçerikId(deleteİçerik.Id);
                if (deledetComment != null)
                {
                    foreach (var item in deledetComment.Data)
                    {
                        _commentService.Delete(item.Id);
                    }
                }
                _içerikDal.Delete(deleteİçerik);
                return new SuccessResult(Messages.İçerik_Deleted);
            }
            return new ErrorResult(Messages.İçerikNotFound);
        }

        [CacheAspects(2)]
        public IDataResult<List<İçerik>> GetAll()
        {
            return new SuccessDataResult<List<İçerik>>(_içerikDal.GetAll(),Messages.İçeriks_Listed);
        }
        [CacheAspects(2)]
        public IDataResult<List<İçerikDetailDto>> GetİçerikDetails()
        {
           return new SuccessDataResult<List<İçerikDetailDto>>(_içerikDal.GetİçerikDetails(), Messages.İçerikWithDetailListed);
        }
        [CacheAspects(2)]
        public IDataResult<İçerik> GetEntityById(int id)
        {
           return new SuccessDataResult<İçerik>(_içerikDal.Get(x=>x.Id==id),Messages.İçerik_Listed);
        }


        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin,user")]
        [CacheRemoveAspect("IİçerikService.Get")]
        public IResult Update(İçerik entity)
        {
            _içerikDal.Update(entity);
            return new SuccessResult(Messages.İçerik_Edit);
        }

       
    }
}
