using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibrarySystem.Infrastructure.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<IEnumerable<Author>> GetAuthorsUsingStoredProcedureAsync()
        {
            return await _context.Authors.FromSqlRaw("GetAllAuthors").ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await FindAll()
                        .OrderBy(author => author.Name)
                        .ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int authorId)
        {
            return await FindByCondition(author => author.Id == authorId)
                        .FirstOrDefaultAsync();
        }

        public void CreateAuthor(Author author)
        {
            Create(author);
        }

        public void UpdateAuthor(Author author)
        {
            Update(author);
        }

        public void DeleteAuthor(Author author)
        {
            Delete(author);
        }

    }
}
