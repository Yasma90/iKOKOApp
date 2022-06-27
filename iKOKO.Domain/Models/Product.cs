using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.Domain.Models
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal CostNet { get; set; }
        public decimal WeightNet { get; set; }
        public int Count { get; set; }
    }
}
