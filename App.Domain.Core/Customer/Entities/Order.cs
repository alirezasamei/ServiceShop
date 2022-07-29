using App.Domain.Core.Expert.Entities;

namespace App.Domain.Core.Customer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ServiceId { get; set; }
        public Service.Entities.Service Service { get; set; }
        public int OrderStateId { get; set; }
        public OrderState OrderState { get; set; }
        public DateTime RegisterDate { get; set; }
        public bool IsDeleted { get; set; }

        public List<Tender> Tenders { get; set; }
    }
}
