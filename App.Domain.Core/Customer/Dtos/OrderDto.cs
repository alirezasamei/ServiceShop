namespace App.Domain.Core.Customer.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public int ServiceId { get; set; }
        public string Service { get; set; }
        public int OrderStateId { get; set; }
        public string OrderState { get; set; }
        public DateTime RegisterDate { get; set; }
    }
}
