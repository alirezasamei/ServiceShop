namespace App.Domain.Core.Expert.Entities
{
    public class PastWork
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User.Entities.User User { get; set; }
        public int ExpertServiceId { get; set; }
        public ExpertService ExpertService { get; set; }
        public long? Price { get; set; }
        public DateTime? ComplitionDate { get; set; }
        public bool IsDeleted { get; set; }

        public List<Evaluation> Evaluations { get; set; }
    }
}
