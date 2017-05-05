using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitTrio.Models
{
    public class IUserRepository
    {
        IQueryable<User> Users { get; }
        User Save(User user);
        User Details(int id);
        User Edit(User user);
        void Remove(User user);
    }
}
