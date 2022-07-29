namespace App.Domain.Core.Customer.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string? Address { get; set; }
    }
}
