using Microsoft.AspNetCore.Mvc;
using MVCBookStoreProject.Data;
using MVCBookStoreProject.Models;
using MVCBookStoreProject.ViewModel;

namespace MVCBookStoreProject.Controllers
{
    public class AuthorsController : Controller
    {
        public ApplicationDbContext context;

        public AuthorsController (ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var authors = context.Authors.ToList();
            var authorsVM = new List<AuthorVM>();

            foreach(var author in authors)
            {
                var authorVM = new AuthorVM()
                {
                    Id = author.Id,
                    Name = author.Name,
                    CreatedOn = author.CreatedOn,
                    UpdatedOn = author.UpdatedOn
                };
                authorsVM.Add(authorVM);
            }

            return View(authorsVM);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Form");
        }

        [HttpPost]
        public IActionResult Create(AuthorVM authorVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", authorVM);
            }

            var author = new Author()
            {
                Name = authorVM.Name
            };

            try
            {
                context.Authors.Add(author);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("Name", "Sorry, Author name already exist!");
                return View("Form", authorVM);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            var authorViewModel = new AuthorFormVM
            {
                Id = id,
                Name = author.Name
            };

            return View("Form", authorViewModel);
        }

        [HttpPost]
        public IActionResult Edit(AuthorFormVM authorVM)
        {
            if (!ModelState.IsValid)
            {
                return View("Form", authorVM);
            }

            var author = context.Authors.Find(authorVM.Id);

            if (author == null)
            {
                return NotFound();
            }

            author.Name = authorVM.Name;
            author.UpdatedOn = DateTime.Now;
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var author = context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            var authorViewModel = new AuthorVM
            {
                Id = author.Id,
                Name = author.Name,
                CreatedOn = author.CreatedOn,
                UpdatedOn = author.UpdatedOn
            };

            return View(authorViewModel);
        }

        public IActionResult Delete(int id)
        {
            var author = context.Authors.Find(id);

            if (author == null)
            {
                return NotFound();
            }

            context.Authors.Remove(author);
            context.SaveChanges();

            return Ok();
        }
    }
}
