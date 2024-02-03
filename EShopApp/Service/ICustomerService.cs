using EShopApp.DTO;
using EShopApp.Models;

namespace EShopApp.Service
{
    public interface ICustomerService
    {
        Task<Customer?> InsertCustomer(CustomerCreateDTO customerDto);
        Task UpdateCustomer(int id, Customer customer);
        Task DeleteCustomer(int id);
        Task<Customer?> GetCustomerById(int id);
        Task<List<Customer>> GetAllCustomers();
    }
}
