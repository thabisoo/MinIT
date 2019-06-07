using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MinIT.Common.ViewModels.User
{
    public class RegisterUserViewModel
    {
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        public string LastName { get; set; }

        [Required]
        [MinLength(2)]
        public string Email { get; set; }
    }

    public class UserViewModel : RegisterUserViewModel
    {
        public string Id { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public IEnumerable<UserViewModel> Users { get; set; }
    }
}
