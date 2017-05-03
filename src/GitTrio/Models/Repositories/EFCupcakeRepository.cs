using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GitTrio.Models
{
    public class EFCupcakeRepository: ICupcakeRepository
    {
        GitTrioContext db = new GitTrioContext();

        public EFCupcakeRepository(GitTrioContext connection = null)
        {
            if (connection == null)
            {
                this.db = new GitTrioContext();
            }
            else
            {
                this.db = connection;
            }
        }
        public IQueryable<Cupcake> Cupcakes
        { get { return db.Cupcakes; } }

        public Cupcake Details(int id)
        {
            return db.Cupcakes.FirstOrDefault(x => x.Id == id);
        }
        public Cupcake Save(Cupcake cupcake)
        {
            db.Cupcakes.Add(cupcake);
            db.SaveChanges();
            return cupcake;
        }

        public Cupcake Edit(Cupcake cupcake)
        {
            db.Entry(cupcake).State = EntityState.Modified;
            db.SaveChanges();
            return cupcake;
        }

        public void Remove(Cupcake cupcake)
        {
            db.Cupcakes.Remove(cupcake);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Cupcakes");
        }
    
    }
}
