using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.Domain.Models
{
    public enum Type { Tanqueta, Vaso }

    public enum Taste { Vainilla, Chocolate, Fresa, Coco, Naranja, Mantecado }

    public class IceCream
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Taste Taste { get; set; }
        public Type Type { get; set; }
        public decimal Cost { get; set; }
        public decimal CostNet { get; set; }
        public int Count { get; set; }
        public int Discount { get; set; }
        public bool Offert { get; set; }
    }
}
