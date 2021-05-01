using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KenKata.Models
{
    public class AccountViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Invalid Email Address.")]
        [EmailAddress]
        public string LoginEmail { get; set; }

        [StringLength(20, ErrorMessage = "Invalid Password.")]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        [DataType(DataType.Text)]
        public string RegisterUserName { get; set; }

        [StringLength(50, ErrorMessage = "Invalid Email Address.")]
        [EmailAddress]
        public string RegisterEmail { get; set; }

        [StringLength(20, ErrorMessage = "Password must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string RegisterPassword { get; set; }
    }
}
