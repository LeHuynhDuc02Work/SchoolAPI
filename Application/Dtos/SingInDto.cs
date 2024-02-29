using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class SignInDto
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}