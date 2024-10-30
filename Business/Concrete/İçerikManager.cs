using Business.Abstract;
using Business.Constans;
using Core.Entities.Concrete;
using Core.Utulities.Result.Abstract;
using Core.Utulities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class İçerikManager : IİçerikService
    {
        IİçerikDal _içerikDal;

        public İçerikManager(IİçerikDal içerikDal)
        {
            _içerikDal=içerikDal;
        }
       
        public IResult Add(İçerik entity)
        {
            _içerikDal.Add(entity);
            return new SuccessResult(Messages.İçerik_Add);
        }

        public IResult Delete(İçerik entity)
        {
            _içerikDal.Delete(entity);
            return new SuccessResult(Messages.İçerik_Deleted);
        }

        public IDataResult<List<İçerik>> GetAll()
        {
            return new SuccessDataResult<List<İçerik>>(_içerikDal.GetAll(),Messages.İçeriks_Listed);
        }

        public IDataResult<İçerik> GetById(int id)
        {
           return new SuccessDataResult<İçerik>(_içerikDal.Get(x=>x.Id==id),Messages.İçerik_Listed);
        }

        public IResult Update(İçerik entity)
        {
            _içerikDal.Update(entity);
            return new SuccessResult(Messages.İçerik_Edit);
        }
    }
}
