using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class İçerikDetailDto:IDto
    {
        public int Id { get; set; }
        public int KonuId { get; set; }

        public int UserId { get; set; }

        public string KonuTitle { get; set; }

        public string Content { get; set; }
        public string UserName { get; set; }

        public List<CommentDetailDto> CommentDetailDtos { get; set; }
    }
}
