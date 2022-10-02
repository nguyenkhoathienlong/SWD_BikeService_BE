using BikeService.Data;
using BikeService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Security.Claims;

namespace BikeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CustomerController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet("/get-all-customer")]
        public async Task<ActionResult<IEnumerable<Customer>>> getAllCustomer()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<Customer>> getCustomerById(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }

    }
}
