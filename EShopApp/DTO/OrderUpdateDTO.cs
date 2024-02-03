using System.ComponentModel.DataAnnotations;

namespace EShopApp.DTO
{
    public class OrderUpdateDTO : BaseDTO
    {
        [Required]
        [Range(0, int.MaxValue)]
        public decimal Amount { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string? Description { get; set; }

        [Required]
        [Range(0, 3)]
        public int Status { get; set; }
    }
}
