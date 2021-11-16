using AutoMapper;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using LibrarySystem.Services.Interfaces;
using LibrarySystem.ViewModels.Author;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AuthorViewModel>> GetAuthorsUsingStoredProcedure()
        {
            var authors = await _unitOfWork.Authors.GetAuthorsUsingStoredProcedureAsync();
            return _mapper.Map<List<AuthorViewModel>>(authors);
        }

        public async Task<List<AuthorViewModel>> GetAllAuthors()
        {
            var authors = await _unitOfWork.Authors.GetAllAuthorsAsync();
            return _mapper.Map<List<AuthorViewModel>>(authors);
        }

        public async Task<AuthorViewModel> GetAuthorById(int authorId)
        {
            var author = await _unitOfWork.Authors.GetAuthorByIdAsync(authorId);
            return _mapper.Map<AuthorViewModel>(author);
        }

        public async Task<bool> CreateNewAuthor(SaveAuthorViewModel authorViewModel)
        {
            try
            {
                var author = _mapper.Map<Author>(authorViewModel);
                _unitOfWork.Authors.CreateAuthor(author);
                await _unitOfWork.Complete();
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error creating the author: ", exp.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAuthor(int authorId, SaveAuthorViewModel authorViewModel)
        {
            try
            {
                var author = _mapper.Map<Author>(authorViewModel);
                _unitOfWork.Authors.UpdateAuthor(author);
                await _unitOfWork.Complete();
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error updating the author: ", exp.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAuthor(int authorId)
        {
            try
            {
                var author = await _unitOfWork.Authors.GetAuthorByIdAsync(authorId);
                if (author == null)
                {
                    throw new Exception("Error deleting the author: not found");
                }
                _unitOfWork.Authors.DeleteAuthor(author);
                await _unitOfWork.Complete();
                return true;
            }
            catch
            {
                throw new Exception("Error deleting the author: has books");
            }

        }
    }
}
