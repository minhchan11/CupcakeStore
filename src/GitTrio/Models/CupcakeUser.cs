using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GitTrio.Models
{
    [Table("CupcakesUsers")]
    public class CupcakeUser
    {
        [Key]
        public int Id { get; set; }
        public virtual Cupcake Cupcake { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
