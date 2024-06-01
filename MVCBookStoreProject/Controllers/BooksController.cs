using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBookStoreProject.Data;
using MVCBookStoreProject.Models;
using MVCBookStoreProject.ViewModel;

namespace MVCBookStoreProject.Controllers
{
    public class BooksController : Controller
    {
        public ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BooksController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var authors = context.Authors.OrderBy(author => author.Name).ToList();
            var categories = context.Categories.OrderBy(category => category.Name).ToList();

            var authorList = new List<SelectListItem>();
            var categoryList = new List<SelectListItem>();

            foreach (var author in authors)
            {
                authorList.Add(new SelectListItem
                {
                    Value = author.Id.ToString(),
                    Text = author.Name
                });
            }

            foreach (var category in categories)
            {
                categoryList.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Name
                });
            }

            var bookVM = new BookFormVM
            {
                Authors = authorList,
                Categories = categoryList
            };

            return View(bookVM);
        }

        [HttpPost]
        public IActionResult Create(BookFormVM bookVM)
        {
            if (!ModelState.IsValid)
            {
                return View(bookVM);
            }

            string ImageName = null;
            if (bookVM.ImgUrl != null)
            {
                ImageName = Path.GetFileName(bookVM.ImgUrl.FileName);

                var path = Path.Combine($"{webHostEnvironment.WebRootPath}/img/Books", ImageName);

                var stream = System.IO.File.Create(path);
                bookVM.ImgUrl.CopyTo(stream);
            }

            var book = new Book {
                Title = bookVM.Title,
                Description = bookVM.Description,
                AuthorId = bookVM.AuthorId,
                Publisher = bookVM.Publisher,
                PublishDate = bookVM.PublishDate,
                ImgUrl = ImageName,
                Categories = bookVM.SelectedCategories.Select(id => new BookCategory
                {
                    CategoryId = id
                }).ToList()
            };
            context.Books.Add(book);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
