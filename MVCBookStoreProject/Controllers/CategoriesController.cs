using Microsoft.AspNetCore.Mvc;
using MVCBookStoreProject.Data;

namespace MVCBookStoreProject.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context) {
            this._context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToList();
            return View(categories);
        }
    }
}
