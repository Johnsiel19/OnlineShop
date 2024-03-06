using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OnlineShopApi.Models.Request
{
    public class CustomerRequestModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Direccion { get; set; }
        public string ClientType { get; set; }
        public string Password { get; set; }
        public DateTime? Date { get; set; }
    }
}
