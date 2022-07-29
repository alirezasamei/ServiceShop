namespace App.Domain.Core.Expert.Dtos
{
    public class ExpertServiceDto
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public string Expert { get; set; }
        public int ServiceId { get; set; }
        public string Service { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }

}
