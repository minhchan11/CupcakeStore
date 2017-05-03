using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GitTrio.Models
{
    public class TestContext : GitTrioContext
    {
        public override DbSet<Cupcake> Cupcakes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=GitTrioTest;integrated security = True");
        }

    }
}
