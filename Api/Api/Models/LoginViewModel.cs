
using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Usuario { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
