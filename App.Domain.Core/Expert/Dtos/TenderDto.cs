namespace App.Domain.Core.Expert.Dtos
{
    public class TenderDto
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public string Expert { get; set; }
        public int OrderId { get; set; }
        public long? Price { get; set; }
        public DateTime RegisterDate { get; set; }
        public TimeSpan? RequiredTime { get; set; }
        public DateTime? StartDate { get; set; }
    }

}
