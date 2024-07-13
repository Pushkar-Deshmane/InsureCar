using InsureCar.Core.Interfaces;
using InsureCar.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace InsureCar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateQuote([FromBody] Quote quote)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var createdQuote = await _quoteService.CreateQuoteAsync(quote);
        //    return CreatedAtAction(nameof(CreateQuote), new { id = createdQuote.Id }, createdQuote);
        //}

        [HttpPost]
        public async Task<IActionResult> CreateQuote([FromBody] CreateQuoteDto createQuoteDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var quote = new Quote
            {
                CustomerId = createQuoteDto.CustomerId,
                CarModel = createQuoteDto.CarModel,
                CarYear = createQuoteDto.CarYear,
                Price = createQuoteDto.Price
            };

            await _quoteService.CreateQuoteAsync(quote);
            return CreatedAtAction(nameof(CreateQuote), new { id = quote.Id }, quote);
        }

        [HttpGet("by-car-model/{carModel}")]
        public async Task<IActionResult> GetQuotesByCarModel(string carModel)
        {
            var quotes = await _quoteService.GetQuotesByCarModelAsync(carModel);
            return Ok(quotes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            await _quoteService.DeleteQuoteAsync(id);
            return NoContent();
        }
    }
}
