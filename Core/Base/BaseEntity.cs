using System.ComponentModel.DataAnnotations;

namespace Core.Base
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}