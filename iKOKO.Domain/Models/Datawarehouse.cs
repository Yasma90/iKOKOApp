using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.Domain.Models
{
    public class Datawarehouse
    {
        public Guid Id{ get; set; }
        public IList<Product> Product { get; set; } = new List<Product>();
        public IList<IceCream> IceCream { get; set; } = new List<IceCream>();
    }
}
