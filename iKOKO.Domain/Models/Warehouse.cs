using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.Domain.Models
{
    public class Warehouse
    {
        [Key]
        public Guid Id{ get; set; }
        [Required]
        public string Name { get; set; }
        public string Address{ get; set; }
        public virtual ICollection<Product> Product { get; set; } = new HashSet<Product>();
        public virtual ICollection<IceCream> IceCream { get; set; } = new HashSet<IceCream>();
    }
}
