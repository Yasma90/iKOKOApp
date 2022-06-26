using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.Domain.Models
{
    public class Product
    {
        public Guid Id{ get; set; }
        public string Name{ get; set; }
        public decimal Cost { get; set; }
        public decimal CostNet { get; set; }
        public decimal WeightNet { get; set; }
        public int Count { get; set; }
    }
}
