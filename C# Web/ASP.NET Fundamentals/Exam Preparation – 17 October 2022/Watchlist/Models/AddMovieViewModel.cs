namespace Watchlist.Models
{
    using System.ComponentModel.DataAnnotations;
    using Watchlist.Data.Models;

    public class AddMovieViewModel
    {
        public AddMovieViewModel()
        {
            this.Genres = new HashSet<Genre>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 10)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Director { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), "0.0", "10.0", ConvertValueInInvariantCulture = true)]
        public decimal Rating { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
    }
}
