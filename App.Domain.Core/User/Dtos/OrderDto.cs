namespace App.Domain.Core.User.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public int ServiceId { get; set; }
        public string Service { get; set; }
        public int OrderStateId { get; set; }
        public string OrderState { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
