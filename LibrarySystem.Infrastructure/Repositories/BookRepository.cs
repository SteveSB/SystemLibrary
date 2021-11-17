using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await FindAll()
                        .Include(b => b.Author)
                        .Include(b => b.SubCategory).ThenInclude(sc => sc.Category)
                        .OrderBy(book => book.Title)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(int authorId)
        {
            return await FindAll()
                        .Where(book => book.AuthorId == authorId)
                        .Include(b => b.Author)
                        .Include(b => b.SubCategory).ThenInclude(sc => sc.Category)
                        .OrderBy(book => book.Title)
                        .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int bookId)
        {
            return await FindByCondition(book => book.Id == bookId)
                        .FirstOrDefaultAsync();
        }

        public async Task<Book> GetBookWithDetailsAsync(int bookId)
        {
            return await FindByCondition(book => book.Id == bookId)
                        .Include(b => b.Author)
                        .Include(b => b.SubCategory).ThenInclude(sc => sc.Category)
                        .FirstOrDefaultAsync();
        }

        public void CreateBook(Book book)
        {
            Create(book);
        }

        public void UpdateBook(Book book)
        {
            Update(book);
        }

        public void DeleteBook(Book book)
        {
            Delete(book);
        }

    }
}
