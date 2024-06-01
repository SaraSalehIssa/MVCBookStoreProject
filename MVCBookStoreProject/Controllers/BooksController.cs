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

        public BooksController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

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
    }
}
