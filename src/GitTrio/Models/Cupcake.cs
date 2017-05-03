using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GitTrio.Models
{
    [Table("Cupcakes")]
    public class Cupcake
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Cake { get; set; }
        public string Frosting { get; set; }
        public string Topping { get; set; }
        public int Inventory { get; set; }
        public string ImgUrl { get; set; }

        public Cupcake()
        {

        }
        public Cupcake(string _name, string _description, int _price, string _cake, string _frosting, string _topping, int _inventory, string _imgUrl, int _id = 0)
        {
            Name = _name;
            Description = _description;
            Price = _price;
            Cake = _cake;
            Frosting = _frosting;
            Topping = _topping;
            Inventory = _inventory;
            ImgUrl = _imgUrl;
        }
        public override bool Equals(System.Object otherCake)
        {
            if (!(otherCake is Cupcake))
            {
                return false;
            }
            else
            {
                Cupcake newCupcake = (Cupcake)otherCake;
                bool IdEquality = Id.Equals(newCupcake.Id);
                bool NameEquality = Name.Equals(newCupcake.Name);
                bool DescriptionEquality = Description.Equals(newCupcake.Description);
                bool PriceEquality = Price.Equals(newCupcake.Price);
                bool CakeEquality = Cake.Equals(newCupcake.Cake);
                bool FrostingEquality = Frosting.Equals(newCupcake.Frosting);
                bool ToppingEquality = Topping.Equals(newCupcake.Topping);
                bool InventoryEquality = Inventory.Equals(newCupcake.Inventory);
                bool ImgUrlEquality = ImgUrl.Equals(newCupcake.ImgUrl);
                return (IdEquality && NameEquality && DescriptionEquality && PriceEquality && CakeEquality && FrostingEquality && ToppingEquality && InventoryEquality && ImgUrlEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
