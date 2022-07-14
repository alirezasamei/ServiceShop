namespace App.Domain.Core.Expert.Dtos
{
    public class EvaluationDto
    {
        public int Id { get; set; }
        public int EvaluationTitleId { get; set; }
        public string EvaluationTitle { get; set; }
        public int PastWorkId { get; set; }
        public int ExpertServiceId { get; set; }
        public short? Score { get; set; }
    }
}
