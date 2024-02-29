namespace Application.Dtos
{
    public class ResultDto
    {
        public double Point { get; set; }
    }

    public class ResultViewDto
    {
        public Guid StudentId { get; set; }
        public Guid ClassId { get; set; }
        public Guid SubjectId { get; set; }
        public double Point { get; set; }
    }
}