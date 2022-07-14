namespace App.Domain.Core.Expert.Entities
{
    public class Evaluation
    {
        public int Id { get; set; }
        public int EvaluationTitleId { get; set; }
        public EvaluationTitle EvaluationTitle { get; set; }
        public int PastWorkId { get; set; }
        public PastWork PastWork { get; set; }
        public int ExpertServiceId { get; set; }
        public ExpertService ExpertService { get; set; }
        public short? Score { get; set; }
    }
}
