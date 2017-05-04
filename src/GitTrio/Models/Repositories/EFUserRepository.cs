using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GitTrio.Models
{
    public class EFUserRepository : IUserRepository
    {
        GitTrioContext db = new GitTrioContext();

        public EFUserRepository(GitTrioContext connection = null)
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
        public IQueryable<User> Users
        { get { return db.Users; } }

        public User Details(int id)
        {
            return db.Users.FirstOrDefault(x => x.UserId == id);
        }
        public User Save(User cupcake)
        {
            db.Users.Add(cupcake);
            db.SaveChanges();
            return cupcake;
        }

        public User Edit(User cupcake)
        {
            db.Entry(cupcake).State = EntityState.Modified;
            db.SaveChanges();
            return cupcake;
        }

        public void Remove(User cupcake)
        {
            db.Users.Remove(cupcake);
            db.SaveChanges();
        }

        public void DeleteAll()
        {
            db.Database.ExecuteSqlCommand("DELETE FROM Users");
        }

    }
}
}
