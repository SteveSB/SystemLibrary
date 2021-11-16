using Domain.Interfaces;
using LibrarySystem.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int bookId);
        Task<Book> GetBookWithDetailsAsync(int bookId);
        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
