using System.ComponentModel.DataAnnotations;

namespace EShopApp.DTO
{
    public class CustomerUpdateDTO : BaseDTO
    {
        [Required]
        [StringLength(10)]
        public string? PhoneNo { get; set; }
        [Required]
        [StringLength(50)]
        public string? Address { get; set; }
    }
}
