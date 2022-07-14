namespace App.Domain.Core.Expert.Dtos
{
    public class PastWorkDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public int ExpertServiceId { get; set; }
        public long? Price { get; set; }
        public DateTime? ComplitionDate { get; set; }
        public bool IsDeleted { get; set; }
    }

}
