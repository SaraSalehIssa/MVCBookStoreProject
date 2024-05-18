using System.ComponentModel.DataAnnotations;

namespace MVCBookStoreProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; } = null!; // Name value is not null 

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime UpdatedOn { get; set; } = DateTime.Now;

        /*
        Category () {
            CreatedOn = DateTime.Now;
            UpdatedOn = DateTime.Now;
        }
        */
    }
}
