using AutoMapper;
using EShopApp.DAO;
using EShopApp.DTO;
using EShopApp.Models;

namespace EShopApp.Service
{
    public class CustomerServiceImpl : ICustomerService
    {
        private readonly ICustomerDAO customerDAO;
        private readonly IMapper mapper;

        // wiring
        public CustomerServiceImpl(ICustomerDAO customerDAO, IMapper mapper)
        {
            this.customerDAO = customerDAO; 
            this.mapper = mapper;
        }

        public async Task<Customer?> InsertCustomer(CustomerCreateDTO customerDto)
        {
            var customer = mapper.Map<Customer>(customerDto);
           /* var customer = new Customer()
            {
                Firstname = customerDto.Firstname,
                Lastname = customerDto.Lastname,
                VatRegNo = customerDto.VatRegNo,
                PhoneNo = customerDto.PhoneNo,
                Address = customerDto.Address,
            };*/

            try
            {
                return await customerDAO.Insert(customer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task UpdateCustomer(int id, Customer customer)
        {
            throw new NotImplementedException();
        }


        public Task DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetCustomerById(int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
