﻿using System.ComponentModel.DataAnnotations;

namespace MVCBookStoreProject.ViewModel
{
    public class CategoryVM
    {
        [Required(ErrorMessage = "Please enter the name")]
        [MaxLength(30, ErrorMessage = "The maximum name length is 30 characters")]
        public string Name { get; set; } = null!; // Name value is not null 
    }
}