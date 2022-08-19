using App.Domain.Core.Customer.Dtos;

namespace App.Domain.Core.Expert.Dtos
{
    public class TenderAndOrderDto
    {
        public TenderDto Tender { get; set; }
        public OrderDto Order { get; set; }
    }
}
