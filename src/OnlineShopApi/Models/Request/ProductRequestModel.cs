using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopApi.Models.Request
{
    public class ProductRequestModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Provider { get; set; }
        public decimal? PurchasPrice { get; set; }
        public decimal? SalePrice { get; set; }
        public int? Stock { get; set; }
        public DateTime? Date { get; set; }
        public int? CustomerId { get; set; }
    }
}
