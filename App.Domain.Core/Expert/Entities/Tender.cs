using App.Domain.Core.Customer.Entities;
namespace App.Domain.Core.Expert.Entities
{
    public class Tender
    {
        public int Id { get; set; }
        public int ExpertId { get; set; }
        public Expert Expert { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public long? Price { get; set; }
        public DateTime RegisterDate { get; set; }
        public TimeSpan? RequiredTime { get; set; }
        public DateTime? StartDate { get; set; }
    }
}
