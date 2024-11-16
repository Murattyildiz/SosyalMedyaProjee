using Core.DataAccess;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfİçerikDal : EfEntityRepository<İçerik, SosyalMedyaContext>, IİçerikDal
    {
        public List<İçerikDetailDto> GetİçerikDetails(Expression<Func<İçerikDetailDto, bool>> filter = null)
        {
           using(var context=new SosyalMedyaContext())
            {
                var result=from A in context.Içeriks
                           join T in context.konus on A.KonuId equals T.Id
                           join U in context.Users on A.UserId equals U.Id
                           select new İçerikDetailDto
                           {
                               Id = A.Id,
                               KonuId = A.KonuId,
                               KonuTitle= T.KonuTitle,
                               Content=A.Content,
                               UserId = A.UserId,
                               UserName = U.FirstName + " " + U.LastName,
                               CommentDetailDtos = ((from C in context.Comments
                                                   join User in context.Users on C.UserId equals User.Id
                                                     where(A.Id == C.İçerikId)
                                                     select new CommentDetailDto
                                                     {
                                                         Id = C.Id,
                                                         İçerikId = C.İçerikId,
                                                         CommentText = C.CommentText,
                                                         UserId = C.UserId,
                                                         UserName = User.FirstName + " " + User.LastName,
                                                         CommentDate = C.CommentDate

                                                     }).ToList()).Count==0 ? new List<CommentDetailDto> { new CommentDetailDto { Id = -1, İçerikId = -1, CommentText = "Henüz Yorum yapılmadı", UserId = -1, UserName = "" } }
                                                     :(from C in context.Comments
                                                       join User in context.Users on C.UserId equals User.Id
                                                       where (A.Id == C.İçerikId)
                                                       select new CommentDetailDto
                                                       {
                                                           Id = C.Id,
                                                           İçerikId = C.İçerikId,
                                                           CommentText = C.CommentText,
                                                           UserId = C.UserId,
                                                           UserName = User.FirstName + " " + User.LastName,
                                                           CommentDate = C.CommentDate

                                                       }).ToList()



                           };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
