namespace App.Domain.Core.Expert.Dtos
{
    public class PastWorkDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public int ExpertServiceId { get; set; }
        public long? Price { get; set; }
        public DateTime? ComplitionDate { get; set; }
    }

}
