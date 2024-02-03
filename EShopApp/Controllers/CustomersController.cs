using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EShopApp.Data;
using EShopApp.Models;
using EShopApp.DTO;
using EShopApp.Service;
using AutoMapper;
using System.Text.RegularExpressions;

namespace EShopApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly EshopDbContext _context;
        private readonly ICustomerService customerService;
        private readonly IMapper mapper;

        private List<Error> errorArray;

        public CustomersController(EshopDbContext context, ICustomerService customerService, IMapper mapper)
            
        {
            _context = context;
            this.customerService = customerService;
            this.mapper = mapper;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadOnlyDTO>>> GetCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            var customersDto = mapper.Map<IEnumerable<CustomerReadOnlyDTO>>(customers);
            return Ok(customersDto);
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadOnlyDTO>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            var customerDto = mapper.Map<CustomerReadOnlyDTO>(customer);
            return Ok(customerDto);
        }

        [HttpGet("GetCustomersByVat/{vat}")]
        public async Task<ActionResult<CustomerReadOnlyDTO>> GetCustomerByVat(string? vat)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(e => e.VatRegNo == vat);
            if (customer == null)
            {
                return NotFound();
            }

            var customerDto = mapper.Map<CustomerReadOnlyDTO>(customer);
            return Ok(customerDto);
        }




        [HttpGet("ValidateVat/{vat}")]
        public async Task<ActionResult<CustomerReadOnlyDTO>> ValidateVat(string vat)
        {
            var isValid = CheckVatRegNo(vat);
            if (!isValid)
            {
                return BadRequest($"{errorArray[0].Code} {errorArray[0].Message} {errorArray[0].Field}");
            }
            return Ok("Is Valid");
        }



        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerCreateDTO>> PostCustomer(CustomerCreateDTO customerDto)
        {
            try
            {
                Customer? insertedCustomer = await customerService.InsertCustomer(customerDto);

                if (insertedCustomer == null)
                {
                    return BadRequest();
                }

                var dto = mapper.Map<CustomerCreateDTO>(insertedCustomer);

                return CreatedAtAction(nameof(GetCustomer), new { id = insertedCustomer.Id }, dto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }


          /*if (_context.Customers == null)
          {
              return Problem("Entity set 'EshopDbContext.Customers'  is null.");
          }
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);*/
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            if (_context.Customers == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return (_context.Customers?.Any(e => e.Id == id)).GetValueOrDefault();
        }






        private bool CheckVatRegNo(string vatRegNo)
        {
            bool validFormat = true;
            if (vatRegNo != null && vatRegNo != "")
            {
                // check pattern
                var pattern = @"^[0-9]{9}$";
                Regex rg = new Regex(pattern);

                if (rg.IsMatch(vatRegNo))
                {
                    var mysum = 0;
                    mysum = Int32.Parse(vatRegNo.Substring(0, 1)) * 256;
                    mysum = mysum + Int32.Parse(vatRegNo.Substring(1, 1)) * 128;
                    mysum = mysum + Int32.Parse(vatRegNo.Substring(2, 1)) * 64;
                    mysum = mysum + Int32.Parse(vatRegNo.Substring(3, 1)) * 32;
                    mysum = mysum + Int32.Parse(vatRegNo.Substring(4, 1)) * 16;
                    mysum = mysum + Int32.Parse(vatRegNo.Substring(5, 1)) * 8;
                    mysum = mysum + Int32.Parse(vatRegNo.Substring(6, 1)) * 4;
                    mysum = mysum + Int32.Parse(vatRegNo.Substring(7, 1)) * 2;

                    var mymod = mysum % 11;
                    if (!(((mymod == 10) && (Int32.Parse(vatRegNo.Substring(8, 1)) == 0)) || ((mymod != 10) && (Int32.Parse(vatRegNo.Substring(8, 1)) == mymod))))
                    {
                        var errorRec = new Error("IncorrectVatRegNo", "Please fill in a correct Vat Reg. No.", "VatRegistrationNo");
                        errorArray.Add(errorRec);
                        validFormat = false;
                    }
                }
                else
                {
                    var errorRec = new Error("IncorrectVatRegNo", "Please fill in a correct Vat Reg. No.", "VatRegistrationNo");
                    errorArray.Add(errorRec);
                    validFormat = false;
                }

            }
            else
            {
                var errorRec = new Error("IncorrectVatRegNo", "VatRegistrationNo Not Found", "VatRegistrationNo");
                errorArray.Add(errorRec);
                validFormat = false;
            }
            return validFormat;
        }
    }
}

