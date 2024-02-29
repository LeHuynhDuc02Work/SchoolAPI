namespace Application.Dtos
{
    public class SubjectDto
    {
        public string Name { get; set; }
        public int NumberOfCredits { get; set; }
    }

    public class SubjectViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfCredits { get; set; }
    }
}