using Business.Abstract;
using Business.Constans;
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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public IResult Add(Comment entity)
        {
            _commentDal.Add(entity);
            return new SuccessResult(Messages.Comment_Add);
        }

        public IResult Delete(Comment entity)
        {
            _commentDal.Delete(entity);
            return new SuccessResult(Messages.Comment_Delete);
        }

        public IDataResult<List<Comment>> GetAll()
        {
            return new SuccessDataResult<List<Comment>>(_commentDal.GetAll(),Messages.Comments_List);
        }

        public IDataResult<Comment> GetById(int id)
        {
           return new SuccessDataResult<Comment>(_commentDal.Get(x=> x.Id == id),Messages.Comment_Listed);
        }

        public IResult Update(Comment entity)
        {
            _commentDal.Update(entity);
            return new SuccessResult(Messages.Comment_Update);
        }
    }
}
