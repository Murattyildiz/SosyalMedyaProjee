﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class İçerik:IEntity
    {
        public int Id { get; set; }

        public int KonuId { get; set; }

        public int UserId { get; set; }

        public int? CommentId { get; set; }

        public string Content { get; set; }

        public DateTime SharingDate { get; set; }
    }
}
