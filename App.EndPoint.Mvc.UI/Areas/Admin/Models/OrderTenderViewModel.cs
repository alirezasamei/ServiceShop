namespace App.EndPoint.Mvc.UI.Areas.Admin.Models
{
    public class OrderTenderViewModel
    {
        public List<TenderViewModel> Tenders { get; set; }
        public OrderViewModel Order { get; set; }
    }
}
