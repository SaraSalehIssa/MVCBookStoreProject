using System.ComponentModel.DataAnnotations;

namespace MVCBookStoreProject.ViewModel
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter the name")]
        [MaxLength(30, ErrorMessage = "The maximum name length is 30 characters")]
        public string Name { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;
    }
}
