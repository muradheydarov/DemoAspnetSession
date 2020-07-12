using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoAspnetSession.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]        
        public string Password { get; set; }

        [Required]
        [NotMapped]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }

    }
}