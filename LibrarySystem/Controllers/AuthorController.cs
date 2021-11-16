using AutoMapper;
using LibrarySystem.Services.Interfaces;
using LibrarySystem.ViewModels.Author;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LibrarySystem.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorService authorService,
            IMapper mapper,
            ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var authors = await _authorService.GetAllAuthors();
            return View(authors);
        }

        public IActionResult Create()
        {
            var authorViewModel = new SaveAuthorViewModel();
            return View("AuthorForm", authorViewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var author = await _authorService.GetAuthorById(id);

            if (author == null)
                return NotFound();

            var authorViewModel = _mapper.Map<SaveAuthorViewModel>(author);

            return View("AuthorForm", authorViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([FromForm] SaveAuthorViewModel authorViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AuthorForm", authorViewModel);
                }

                if (authorViewModel.Id == 0)
                    await _authorService.CreateNewAuthor(authorViewModel);
                else
                    await _authorService.UpdateAuthor(authorViewModel.Id, authorViewModel);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("AuthorForm", authorViewModel);
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _authorService.DeleteAuthor(id);
                if (!isDeleted)
                {
                    Response.StatusCode = 500;
                    return Json("Something went wrong");
                }
                return Json("Deleted");
            }
            catch (Exception exp)
            {
                Response.StatusCode = 500;
                return Json(exp.Message);
            }
        }
    }
}
