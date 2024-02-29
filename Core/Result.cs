using System.ComponentModel.DataAnnotations;

namespace Core
{
    public class Result    
    {
        public Guid StudentId { get; set; }
        public Guid ClassId { get; set; }
        public Guid SubjectId { get; set; }
        [Range(0, double.MaxValue)]
        public double Point { get; set; }

        public Student Student { get; set; }
        public Class Class { get; set; }
        public Subject Subject { get; set; }
    }
}