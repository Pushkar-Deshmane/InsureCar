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
    public class QuoteService : IQuoteService
    {
        private readonly ApplicationDbContext _context;

        public QuoteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Quote> CreateQuoteAsync(Quote quote)
        {
            _context.Quotes.Add(quote);
            await _context.SaveChangesAsync();
            return quote;
        }

        public async Task<IEnumerable<Quote>> GetQuotesByCarModelAsync(string carModel)
        {
            return await _context.Quotes
                .Where(q => q.CarModel == carModel)
                .ToListAsync();
        }

        public async Task DeleteQuoteAsync(int id)
        {
            var quote = await _context.Quotes.FindAsync(id);
            if (quote != null)
            {
                _context.Quotes.Remove(quote);
                await _context.SaveChangesAsync();
            }
        }
    }
}
