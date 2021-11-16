using AutoMapper;
using LibrarySystem.Services.Interfaces;
using LibrarySystem.ViewModels.Author;
using LibrarySystem.ViewModels.Book;
using LibrarySystem.ViewModels.Category;
using LibrarySystem.ViewModels.SubCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LibrarySystem.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookService bookService,
            IAuthorService authorService,
            ICategoryService categoryService,
            ISubCategoryService subCategoryService,
            IMapper mapper,
            ILogger<BookController> logger)
        {
            _bookService = bookService;
            _authorService = authorService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _mapper = mapper;
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

            return await InitializeBookFormView(bookViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetBookById(id);

            if (book == null)
                return NotFound();

            var bookViewModel = _mapper.Map<SaveBookViewModel>(book);

            return await InitializeBookFormView(bookViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([FromForm] SaveBookViewModel bookViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return await InitializeBookFormView(bookViewModel);
                }

                if (bookViewModel.Id == 0)
                    await _bookService.CreateNewBook(bookViewModel);
                else
                    await _bookService.UpdateBook(bookViewModel.Id, bookViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return await InitializeBookFormView(bookViewModel);
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

        public async Task<JsonResult> GetSubCategories(int categoryId)
        {
            var subCategories = await _subCategoryService.GetSubCategoriesUsingStoredProcedure(categoryId);

            return Json(new SelectList(subCategories, "Id", "Name"));
        }

        private async Task<IActionResult> InitializeBookFormView(SaveBookViewModel bookViewModel)
        {
            var authors = await _authorService.GetAuthorsUsingStoredProcedure();
            //authors.Insert(0, new AuthorViewModel() { Id = 0, Name = "Select" });
            bookViewModel.Authors = new SelectList(authors, "Id", "Name");

            var categories = await _categoryService.GetCategoriesUsingStoredProcedure();
            //categories.Insert(0, new CategoryViewModel() { Id = 0, Name = "Select" });
            bookViewModel.Categories = new SelectList(categories, "Id", "Name");

            var subCategories = await _subCategoryService.GetSubCategoriesUsingStoredProcedure(bookViewModel.CategoryId);
            //subCategories.Insert(0, new SubCategoryViewModel() { Id = 0, Name = "Select" });
            bookViewModel.SubCategories = new SelectList(subCategories, "Id", "Name");

            return View("BookForm", bookViewModel);
        }

    }
}
