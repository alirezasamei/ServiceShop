namespace App.EndPoint.Mvc.UI.Models
{
    public class OrderTenderViewModel
    {
        public List<TenderViewModel> Tenders { get; set; }
        public OrderViewModel Order { get; set; }
    }
}
