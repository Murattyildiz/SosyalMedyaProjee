using Core.Entities;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Context
{
    public class SosyalMedyaContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=MURATYıLDıZ\MSSQLSERVER22;Database=SosyalMedya;Trusted_Connection=true;TrustServerCertificate=true;");
        }
        public DbSet<User> Users { get; set; }

        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public DbSet<İçerik> Içeriks { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Konu> konus { get; set; }

    }
}
