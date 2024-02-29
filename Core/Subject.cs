using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Subject : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Range(2, 8)]
        public int NumberOfCredits { get; set; }

        public ICollection<Result> Results { get; set; }

    }
}