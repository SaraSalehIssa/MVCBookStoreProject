using System.ComponentModel.DataAnnotations;

namespace MVCBookStoreProject.ViewModel
{
    public class AuthorFormVM
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The maximum name length is 50 characters")]
        public string Name { get; set; }
    }
}
