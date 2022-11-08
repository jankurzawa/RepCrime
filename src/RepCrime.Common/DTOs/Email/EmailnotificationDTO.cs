namespace RepCrime.Common.DTOs.Email
{
    public class EmailnotificationDTO
    {
        public List<string> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
