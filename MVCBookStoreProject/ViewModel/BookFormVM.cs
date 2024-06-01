using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBookStoreProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCBookStoreProject.ViewModel
{
    public class BookFormVM
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        public List<SelectListItem> Authors { get; set; }

        public string Publisher { get; set; } = null!;

        [Display(Name = "Publish Date")]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Display(Name = "Image")]
        public IFormFile? ImgUrl { get; set; }

        public List<int> SelectedCategories { get; set; } = new List<int>();
        public List<SelectListItem> Categories { get; set; }
    }
}
