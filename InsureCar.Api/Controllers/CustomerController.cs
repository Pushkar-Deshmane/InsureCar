using InsureCar.Core.Interfaces;
using InsureCar.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsureCar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCustomer = await _customerService.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(CreateCustomer), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            await _customerService.UpdateCustomerAsync(customer);
            return NoContent();
        }

        [HttpGet("quotes-over-amount/{amount}")]
        public async Task<IActionResult> GetCustomersWithQuotesOverAmount(decimal amount)
        {
            var customers = await _customerService.GetCustomersWithQuotesOverAmountAsync(amount);
            return Ok(customers);
        }
    }
}
