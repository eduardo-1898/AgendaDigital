using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DomainModels
{
    public partial class ASTDBContext : DbContext
    {
        public ASTDBContext() { 
        
        }
        public ASTDBContext(DbContextOptions<ASTDBContext> options)
: base(options)
        {
        }

        //public virtual DbSet<TypeWorkDay> TypeWorkDay { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<TypeWorkDay>(entity =>
            //{
            //    entity.HasKey(e => e.jornada);

            //});
        }
    }
}
