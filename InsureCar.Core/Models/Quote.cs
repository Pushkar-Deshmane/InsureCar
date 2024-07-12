using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsureCar.Core.Models
{
    public class Quote
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CarModel { get; set; }
        public int CarYear { get; set; }
        public decimal Price { get; set; }
        public Customer Customer { get; set; }
    }
}
