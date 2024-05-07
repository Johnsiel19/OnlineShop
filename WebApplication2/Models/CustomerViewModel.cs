namespace OnlineShopWeb.Models
{
    public class CustomerViewModel
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
