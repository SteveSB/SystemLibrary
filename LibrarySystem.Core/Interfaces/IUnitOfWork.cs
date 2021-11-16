using System;
using System.Threading.Tasks;

namespace LibrarySystem.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        ICategoryRepository Categories { get; }

        Task Complete();
    }
}
