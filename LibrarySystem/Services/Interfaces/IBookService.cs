using LibrarySystem.Dtos.Book;
using LibrarySystem.ViewModels.Book;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<BookViewModel>> GetAllBooks();

        Task<List<BookDto>> GetBooksByAuthor(int authorId);

        Task<BookViewModel> GetBookById(int bookId);

        Task<bool> CreateNewBook(SaveBookViewModel bookViewModel);

        Task<bool> UpdateBook(int bookId, SaveBookViewModel bookViewModel);

        Task<bool> DeleteBook(int bookId);
    }
}
