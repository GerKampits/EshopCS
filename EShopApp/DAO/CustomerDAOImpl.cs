using EShopApp.Data;
using EShopApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EShopApp.DAO
{
    public class CustomerDAOImpl : ICustomerDAO
    {
        // DbContext
        private readonly EshopDbContext _context;

        public CustomerDAOImpl(EshopDbContext context)
        {
            _context = context;
        }







        public async Task<Customer?> Insert(Customer customer)
        {
            if (_context.Customers == null)
            {
                return null;
            }

            _context.Customers.Add(customer); // add στο DBset
            await _context.SaveChangesAsync(); // commit  // στην βαση.
            return customer;
        }

        public async Task<bool> Update(int id, Customer customer)
        {
            bool updated;

            if (id != customer.Id)
            {
                return false;
            }
            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                updated = true;
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!CustomerExists(id))
                {
                    updated = false;
                }
                else
                {
                    throw;
                }
            }
            return updated;
        }


       

        public async Task<bool> Delete(int id)
        {
            {
                if (_context.Customers == null)
                {
                    return false;
                }
                var customer = await _context.Customers.FindAsync(id);
                if (customer == null)
                {
                    return false;
                }

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<List<Customer>> GetAll()
        {
            var list = new List<Customer>();

            if (_context.Customers == null)
            {
                return list;
            }
            list = await _context.Customers.ToListAsync();
            return list;
        }

        public async Task<Customer?> GetById(int id)
        {
            if (_context.Customers == null)
            {
                return null;
            }
            return  await _context.Customers.FindAsync(id);
        }





        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }

    }
}
