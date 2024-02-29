namespace Application.Dtos
{
    public class ClassDto
    {
        public string Name { get; set; }
        public string HomeroomTeacher { get; set; }
        public Guid FacultyId { get; set; }
    }

    public class ClassViewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HomeroomTeacher { get; set; }
        public Guid FacultyId { get; set; }
    }
}