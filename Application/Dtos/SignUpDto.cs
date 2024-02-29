using System.ComponentModel.DataAnnotations;

namespace Application.Dtos
{
    public class SignUpDto
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Possition { get; set; } = null!;

        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}