using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Comment:IEntity
    {
        public int Id {  get; set; }

        public int İçerikId {  get; set; }
        
        public int UserId { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }
    }
}
