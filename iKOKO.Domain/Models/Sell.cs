using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.Domain.Models
{
    public class Sell
    {
        public Guid Id { get; set; }
        public DateTime Day { get; set; }
        public Client Client { get; set; } = new Client();
        public IList<IceCream> IceCreams { get; set; } = new List<IceCream>();
        public decimal Total { get { return IceCreams.Sum(i => i.Cost); } }
    }
}
