using LibrarySystem.Services.Interfaces;
using LibrarySystem.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LibrarySystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService, ILogger<BookController> logger)
        {
            _bookService = bookService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllBooks();

            return View(books);
        }

        public async Task<IActionResult> Create()
        {
            var bookViewModel = new SaveBookViewModel();

            //var authors = await _authorService.GetAllAuthors();
            //bookViewModel.Authors = new SelectList(authors, "Id", "Name");

            //var categories = await _categoryService.GetAllCategories();
            //bookViewModel.Categories = new SelectList(categories, "Id", "Name");

            return View("BookForm", bookViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookById(id);

            if (book == null)
                return NotFound();

            return View("BookForm", book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([FromForm] SaveBookViewModel bookViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("BookForm", bookViewModel);
                }

                if (bookViewModel.Id == 0)
                    await _bookService.CreateNewBook(bookViewModel);
                else
                    await _bookService.UpdateBook(bookViewModel.Id, bookViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("BookForm", bookViewModel);
            }
        }

        [HttpPost]
        public async Task<bool> Delete(int id)
        {
            try
            {
                var isDeleted = await _bookService.DeleteBook(id);
                return isDeleted;
            }
            catch
            {
                return false;
            }
        }
    }
}
