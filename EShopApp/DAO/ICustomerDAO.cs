using EShopApp.Models;

namespace EShopApp.DAO
{
    public interface ICustomerDAO
    {
        Task<Customer?> Insert(Customer customer);
        Task<bool> Update(int id, Customer customer);
        Task<bool> Delete(int id);
        Task<Customer?> GetById(int id);
        Task<List<Customer>> GetAll();
    }
}
