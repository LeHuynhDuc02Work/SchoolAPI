using Core.Base;
using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Faculty : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Class> Classes { get; set; }

    }
}