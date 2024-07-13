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
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1980, 1, 1),
                Address = "123 Main St"
            };

            var createdCustomer = await _customerService.CreateCustomerAsync(customer);

            Assert.NotNull(createdCustomer);
            Assert.Equal("John", createdCustomer.FirstName);
        }

        [Fact]
        public async Task UpdateCustomerAsync_ShouldUpdateCustomer()
        {
            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1980, 1, 1),
                Address = "123 Main St"
            };

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            customer.LastName = "Smith";
            await _customerService.UpdateCustomerAsync(customer);

            var updatedCustomer = await _context.Customers.FindAsync(customer.Id);
            Assert.Equal("Smith", updatedCustomer.LastName);
        }

        [Fact]
        public async Task GetCustomersWithQuotesOverAmountAsync_ShouldReturnCustomers()
        {
            var customer = new Customer
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1980, 1, 1),
                Address = "123 Main St",
                Quotes = new List<Quote>
            {
                new Quote { CarModel = "Toyota Camry", CarYear = 2020, Price = 600 }
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
