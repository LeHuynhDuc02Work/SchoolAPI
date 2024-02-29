namespace Application.Dtos
{
    public class InputSearchDto
    {
        public InputSearchDto()
        {
            page = 1;
            pageSize = 5;
            search = "";
        }
        public string? search { get; set; } 
        public int page { get; set; } 
        public int pageSize { get; set; } 
    }
}