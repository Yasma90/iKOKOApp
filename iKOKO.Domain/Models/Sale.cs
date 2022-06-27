using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.Domain.Models
{
    public class Sale
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public DateTime Created { get; set; } = DateTime.Now;
        [Required]
        public virtual Guid ClientId { get; set; }
        public virtual Client Client { get; set; } = new Client();
        public virtual ICollection<IceCream> IceCreams { get; set; } = new HashSet<IceCream>();
        public decimal Total { get { return IceCreams.Sum(i => i.Cost); } }
    }
}
