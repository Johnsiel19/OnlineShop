namespace OnlineShopWeb.Models
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }   
    }
}
