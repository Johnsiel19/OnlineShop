namespace OnlineShopApi.Models.Response
{
    public class OrderResponseModel
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();
    }
}
