namespace Watchlist.Services
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Watchlist.Contracts;
    using Watchlist.Data;
    using Watchlist.Data.Models;
    using Watchlist.Models;

    public class MovieService : IMovieService
    {
        private readonly WatchlistDbContext context;

        public MovieService(WatchlistDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync()
        {
            var result = await this.context.Movies
                .Select(m => new MovieViewModel() 
                {
                    Id = m.Id,
                    Title = m.Title,
                    Director = m.Director,
                    ImageUrl = m.ImageUrl,
                    Rating = m.Rating,
                    Genre = m.Genre.Name
                }).ToArrayAsync();

            return result;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await context.Genres.ToListAsync();
        }

        public async Task AddMovieAsync(AddMovieViewModel model)
        {
            var entity = new Movie()
            {
                //Id = model.Id,
                Title = model.Title,
                Director = model.Director,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating,
                GenreId = model.GenreId,
            };

            await context.Movies.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task AddMovieToCollectionAsync(int movieId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync();    

            if (user == null)
            {
                throw new ArgumentException("Invalid User Id");
            }

            var movie = await context.Movies.FirstOrDefaultAsync(m => m.Id == movieId);

            if (movie == null) 
            {
                throw new ArgumentException("Invalid Movie Id");
            }

            if (!user.UsersMovies.Any(m => m.MovieId == movieId))
            {
                user.UsersMovies.Add(new UserMovie()
                {
                    MovieId = movieId,
                    UserId = userId,
                    Movie = movie,
                    User = user
                });

                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<MovieViewModel>> GetWatchedMoviesAsync(string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .ThenInclude(um => um.Movie)
                .ThenInclude(m => m.Genre)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid User Id");
            }

            return user.UsersMovies
                .Select(m => new MovieViewModel()
                {
                    Id = m.Movie.Id,
                    Title = m.Movie.Title,
                    Director = m.Movie.Director,
                    ImageUrl = m.Movie.ImageUrl,
                    Rating = m.Movie.Rating,
                    Genre = m.Movie.Genre.Name
                });
        }

        public async Task RemoveMovieFromCollectionAsync(int movieId, string userId)
        {
            var user = await context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.UsersMovies)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new ArgumentException("Invalid User Id");
            }

            var movie = user.UsersMovies.FirstOrDefault(m => m.MovieId == movieId);

            if (movie != null)
            {
                user.UsersMovies.Remove(movie);
            }

            await context.SaveChangesAsync();
        }
    }
}
