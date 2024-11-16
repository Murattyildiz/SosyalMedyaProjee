using Core.Service;
using Core.Utulities.Result.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IİçerikService:IServiceRepository<İçerik>
    {

     IDataResult<List<İçerikDetailDto>> GetİçerikDetails();
     //IDataResult<List<İçerikDetailsDto>> GetArticleDetailsByUserId(int id);
     //IDataResult<İçerikDetailslDto> GetArticleDetailsById(int id);
    }
}
