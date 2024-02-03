using System.ComponentModel.DataAnnotations;

namespace EShopApp.DTO
{
    public class CustomerCreateDTO
    {

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "The {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage ="Space are not allowed")]
        public string? Firstname { get; set; }


        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(50, ErrorMessage = "The {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Space are not allowed")]
        public string? Lastname { get; set;}

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(9, ErrorMessage = "The {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Space are not allowed")]
        public string? VatRegNo { get; set;}

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(10, ErrorMessage = "The {0} field must be maximum of {1} characters")]
        [RegularExpression(@"^[^\s]+$", ErrorMessage = "Space are not allowed")]
        public string? PhoneNo { get; set; }

        [Required(ErrorMessage = "The {0} field is required")]
        [StringLength(100, ErrorMessage = "The {0} field must be maximum of {1} characters")]
        public string? Address { get; set; }


    }
}
