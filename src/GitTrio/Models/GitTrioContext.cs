using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GitTrio.Models
{
    public class GitTrioContext : DbContext
    {
        public GitTrioContext()
        {
        }

        public virtual DbSet<Cupcake> Cupcakes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GitTrio;integrated security=True");
        }

        public GitTrioContext(DbContextOptions<GitTrioContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
