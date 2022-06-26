using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.Domain.Models
{
    public class Client
    {
        public Guid Id{ get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string CI { get; set; }
        public short Sex { get; set; }
        public bool VIP { get; set; }
    }
}
