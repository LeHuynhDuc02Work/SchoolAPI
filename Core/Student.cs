using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Student : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Guid ClassId { get; set; }
        public Class Class { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}