using InsureCar.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureCar.Core.Interfaces
{
    public interface IQuoteService
    {
        Task<Quote> CreateQuoteAsync(Quote quote);
        Task<IEnumerable<Quote>> GetQuotesByCarModelAsync(string carModel);
        Task DeleteQuoteAsync(int id);
    }
}
