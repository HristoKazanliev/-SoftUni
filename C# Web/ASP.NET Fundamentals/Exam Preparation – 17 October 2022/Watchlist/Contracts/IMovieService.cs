namespace Watchlist.Contracts
{
    using Watchlist.Data.Models;
    using Watchlist.Models;

    public interface IMovieService
    {
        Task<IEnumerable<MovieViewModel>> GetAllMoviesAsync();

        Task<IEnumerable<Genre>> GetGenresAsync();

        Task AddMovieAsync(AddMovieViewModel model);

        Task AddMovieToCollectionAsync(int movieId, string userId);

        Task<IEnumerable<MovieViewModel>> GetWatchedMoviesAsync(string userId);

        Task RemoveMovieFromCollectionAsync(int movieId, string userId);
    }
}
