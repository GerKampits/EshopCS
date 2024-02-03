namespace EShopApp.DTO
{
    public class CustomerReadOnlyDTO : BaseDTO
    {
        public string? Firstname { get; set; }  

        public string? Lastname { get; set; }
        
        public string? VatRegNo { get; set; }

        public string? PhoneNo { get; set; }

        public string? Address { get; set; }
    }
    
}
