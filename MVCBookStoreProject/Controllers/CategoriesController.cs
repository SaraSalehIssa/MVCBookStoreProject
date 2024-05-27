using Microsoft.AspNetCore.Mvc;
using MVCBookStoreProject.Data;
using MVCBookStoreProject.Models;
using MVCBookStoreProject.ViewModel;

namespace MVCBookStoreProject.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoriesController(ApplicationDbContext context) {
            this.context = context;
        }

        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", categoryVM);
            }

            var category = new Category()
            {
                Name = categoryVM.Name
            };

            context.Categories.Add(category);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryViewModel = new CategoryVM
            {
                Id = id,
                Name = category.Name
            };

            return View("Create", categoryViewModel);
        }

        [HttpPost]
        public IActionResult Edit(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid) {
                return View("Create", categoryVM);
            }

            var category = context.Categories.Find(categoryVM.Id);

            if (category == null)
            {
                return NotFound();
            }

            category.Name = categoryVM.Name;
            category.UpdatedOn = DateTime.Now;
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Details(int id) {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            var categoryViewModel = new CategoryVM
            {
                Id = category.Id,
                Name = category.Name,
                CreatedOn = category.CreatedOn,
                UpdatedOn = category.UpdatedOn
            };

            return View(categoryViewModel);
        }

        public IActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            return Ok();
        }
    }
}
