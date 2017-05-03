using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GitTrio.Models
{
    public interface ICupcakeRepository
    {
        IQueryable<Cupcake> Cupcakes { get; }
        Cupcake Save(Cupcake cupcake);
        Cupcake Details(int id);
        Cupcake Edit(Cupcake cupcake);
        void Remove(Cupcake cupcake);
    }
}
