namespace Watchlist.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        public User()
        {
            this.UsersMovies = new HashSet<UserMovie>();
        }

        public virtual ICollection<UserMovie> UsersMovies { get; set; }
    }
}
