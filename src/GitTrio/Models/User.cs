using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GitTrio.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<CupcakeUser> CupcakesUsers { get; set; }

        public User()
        {

        }
        public User(string _username, string _password, int _id = 0)
        {
            Username = _username;
            Password = _password;
        }
        public override bool Equals(System.Object otherUser)
        {
            if (!(otherUser is User))
            {
                return false;
            }
            else
            {
                User newUser = (User)otherUser;
                bool IdEquality = UserId.Equals(newUser.UserId);
                bool UsernameEquality = Username.Equals(newUser.Username);
                bool PasswordEquality = Password.Equals(newUser.Password);
                return (IdEquality && UsernameEquality && PasswordEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.UserId.GetHashCode();
        }
    }
}
