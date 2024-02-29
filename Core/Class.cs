using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Class : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string HomeroomTeacher { get; set; }
        public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Result> Results { get; set; }
    }
}