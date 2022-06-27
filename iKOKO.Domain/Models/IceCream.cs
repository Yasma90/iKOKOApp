using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.Domain.Models
{
    public enum Type { Tanqueta, Vaso }

    public enum Taste { Vainilla, Chocolate, Fresa, Coco, Naranja, Mantecado }

    public class IceCream
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Taste Taste { get; set; }
        [Required]
        public Type Type { get; set; }
        public decimal Cost { get; set; }
        public decimal CostNet { get; set; }
        public int Count { get; set; }
        public int Discount { get; set; }
        public bool Offert { get; set; }
        //public virtual Guid SaleId { get; set; }
        //public virtual Sale Sale { get; set; }
    }
}
