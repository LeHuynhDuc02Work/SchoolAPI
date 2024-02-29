namespace Application.Dtos
{
    public class StudentDto
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Guid ClassId { get; set; }
    }

    public class StudentViewDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Guid ClassId { get; set; }
    }
}