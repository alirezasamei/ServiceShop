namespace App.Domain.Core.Operator.Dtos
{
    public class OperatorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Mobile { get; set; }
        public string Email { get; set; }
        public DateTime SubmitDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
    }
}
