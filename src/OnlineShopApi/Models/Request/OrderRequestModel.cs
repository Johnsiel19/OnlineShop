using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShopApi.Models.Request
{
    public class OrderRequestModel
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Total { get; set; }   
    }
}
