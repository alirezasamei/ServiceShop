using System.ComponentModel.DataAnnotations;

namespace App.Domain.Core.Expert.Entities
{
    public class EvaluationTitle
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public List<Evaluation> Evaluations { get; set; }
    }
}
