using Library.Models;

namespace Library.Contracts
{
    public interface IBookService
    {
        Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();

        Task<IEnumerable<AllBookViewModel>> GetMineBooksAsync(string userId);

        Task<BookViewModel?> GetBookByIdAsync(int id);

        Task AddBookToCollectionAsync(string userId, BookViewModel model);

        Task RemoveBookFromCollectionAsync(string userId, BookViewModel model);

        Task<AddBookViewModel> GetNewAddBookModelAsync();

        Task AddBookAsync(AddBookViewModel model);

        Task<AddBookViewModel?> GetBookByIdForEditAsync(int id);

        Task EditBookAsync(AddBookViewModel model, int id);
    }
}
