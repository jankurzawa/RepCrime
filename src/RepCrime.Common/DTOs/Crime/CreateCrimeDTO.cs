namespace RepCrime.Common.DTOs.Crime
{
    public class CreateCrimeDTO
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Required]
        public CrimeType Type { get; set; }

        public string? Description { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
