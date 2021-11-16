using Domain.Interfaces;
using LibrarySystem.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Interfaces
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<IEnumerable<Author>> GetAuthorsUsingStoredProcedureAsync();
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int authorId);
        void CreateAuthor(Author author);
        void UpdateAuthor(Author author);
        void DeleteAuthor(Author author);
    }
}
