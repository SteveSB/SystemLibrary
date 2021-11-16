using LibrarySystem.ViewModels.Author;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorViewModel>> GetAuthorsUsingStoredProcedure();
        Task<List<AuthorViewModel>> GetAllAuthors();

        Task<AuthorViewModel> GetAuthorById(int authorId);

        Task<bool> CreateNewAuthor(SaveAuthorViewModel authorViewModel);

        Task<bool> UpdateAuthor(int authorId, SaveAuthorViewModel authorViewModel);

        Task<bool> DeleteAuthor(int authorId);
    }
}
