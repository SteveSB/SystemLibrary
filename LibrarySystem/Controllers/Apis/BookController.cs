using AutoMapper;
using LibrarySystem.Services.Interfaces;
using LibrarySystem.ViewModels.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibrarySystem.Controllers.Apis
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService,
            ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        [HttpGet]
        [Route("getAuthorBooks")]
        public async Task<ActionResult<IEnumerable<BookViewModel>>> GetAuthorBooks([FromQuery] int authorId)
        {
            var books = await _bookService.GetAllBooks();
            return books;
        }

        [HttpGet]
        [Route("getBookById/{id:int}")]
        public async Task<ActionResult<BookViewModel>> GetBookById(int id)
        {
            var book = await _bookService.GetBookById(id);
            return book;
        }
    }
}
