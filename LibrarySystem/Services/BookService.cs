using AutoMapper;
using LibrarySystem.Core.Interfaces;
using LibrarySystem.Core.Models;
using LibrarySystem.Dtos.Book;
using LibrarySystem.Services.Interfaces;
using LibrarySystem.ViewModels.Book;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<BookViewModel>> GetAllBooks()
        {
            var books = await _unitOfWork.Books.GetAllBooksAsync();
            return _mapper.Map<List<BookViewModel>>(books);
        }

        public async Task<List<BookDto>> GetBooksByAuthor(int authorId)
        {
            var books = await _unitOfWork.Books.GetBooksByAuthorAsync(authorId);
            return _mapper.Map<List<BookDto>>(books);
        }

        public async Task<BookViewModel> GetBookById(int bookId)
        {
            var book = await _unitOfWork.Books.GetBookWithDetailsAsync(bookId);
            return _mapper.Map<BookViewModel>(book);
        }

        public async Task<bool> CreateNewBook(SaveBookViewModel bookViewModel)
        {
            try
            {
                var book = _mapper.Map<Book>(bookViewModel);
                _unitOfWork.Books.CreateBook(book);
                await _unitOfWork.Complete();
                return true;
            }
            catch(Exception exp)
            {
                Console.WriteLine("Error creating the book: ", exp.Message);
                return false;
            }
        }

        public async Task<bool> UpdateBook(int bookId, SaveBookViewModel bookViewModel)
        {
            try
            {
                var book = _mapper.Map<Book>(bookViewModel);
                _unitOfWork.Books.UpdateBook(book);
                await _unitOfWork.Complete();
                return true;
            }
            catch (Exception exp)
            {
                Console.WriteLine("Error updating the book: ", exp.Message);
                return false;
            }
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            try
            {
                var book = await _unitOfWork.Books.GetBookByIdAsync(bookId);
                if (book == null)
                {
                    throw new Exception("Error deleting the book: not found");
                }
                _unitOfWork.Books.DeleteBook(book);
                await _unitOfWork.Complete();
                return true;
            }
            catch (Exception exp)
            {
                throw new Exception("Error deleting the book: " + exp.Message);
            }

        }
    }
}
