using System.ComponentModel.DataAnnotations;
using EShopApp.Models;

namespace EShopApp.DTO
{
    public class OrderCreateDTO
    {
        [Required]
        [Range(0, int.MaxValue)]
        public decimal? Amount { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string? Description { get; set; }
        [Required]
        [Range(0, 3)]
        public int? Status { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1/1/2000", "1/1/2050", ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime? Date { get; set; }

       
    }
}
