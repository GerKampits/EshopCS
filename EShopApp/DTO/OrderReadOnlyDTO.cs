using EShopApp.Models;

namespace EShopApp.DTO
{
    public class OrderReadOnlyDTO : BaseDTO
    {

        public decimal? Amount { get; set; }

        public string? Description { get; set; }

        public int? Status { get; set; }

        public DateTime? Date { get; set; }

        public int? CustomerId { get; set; }

        public string? CustomerName { get; set; }
    }
}
