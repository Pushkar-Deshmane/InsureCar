using InsureCar.Core.Interfaces;
using InsureCar.Core.Models;
using InsureCar.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureCar.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Customer>> GetCustomersWithQuotesOverAmountAsync(decimal amount)
        {
            return await _context.Customers
                .Include(c => c.Quotes)
                .Where(c => c.Quotes.Any(q => q.Price > amount))
                .ToListAsync();
        }
    }
}
