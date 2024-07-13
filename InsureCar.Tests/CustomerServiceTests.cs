using InsureCar.Core.Interfaces;
using InsureCar.Core.Models;
using InsureCar.Infrastructure.Data;
using InsureCar.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;

namespace InsureCar.Tests
{
    public class CustomerServiceTests
    {
        private readonly ICustomerService _customerService;
        private readonly ApplicationDbContext _context;

        public CustomerServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "InsureCarDb")
            .Options;

            _context = new ApplicationDbContext(options);
            _customerService = new CustomerService(_context);
        }

        [Fact]
        public async Task CreateCustomerAsync_ShouldAddCustomer()
        {
            var customer = new Customer
            {
                FirstName = "Pushkar",
                LastName = "Deshmane",
                DateOfBirth = new DateTime(1980, 1, 1),
                Address = "123 Cork St"
            };

            var createdCustomer = await _customerService.CreateCustomerAsync(customer);

            Assert.NotNull(createdCustomer);
            Assert.Equal("Pushkar", createdCustomer.FirstName);
        }

        [Fact]
        public async Task UpdateCustomerAsync_ShouldUpdateCustomer()
        {
            var customer = new Customer
            {
                FirstName = "Pushkar",
                LastName = "Deshmane",
                DateOfBirth = new DateTime(1980, 1, 1),
                Address = "123 Cork St"
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            customer.LastName = "Messi";
            await _customerService.UpdateCustomerAsync(customer);

            var updatedCustomer = await _context.Customers.FindAsync(customer.Id);
            Assert.Equal("Messi", updatedCustomer.LastName);
        }

        [Fact]
        public async Task GetCustomersWithQuotesOverAmountAsync_ShouldReturnCustomers()
        {
            var customer = new Customer
            {
                FirstName = "Pushkar",
                LastName = "Deshmane",
                DateOfBirth = new DateTime(1980, 1, 1),
                Address = "123 Cork St",
                Quotes = new List<Quote>
            {
                new Quote { CarModel = "BMW 330e", CarYear = 2019, Price = 600 }
            }
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            var customers = await _customerService.GetCustomersWithQuotesOverAmountAsync(500);

            Assert.NotEmpty(customers);
            Assert.Single(customers);
        }
    }
}
