using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iKOKO.Domain.Models
{
    public enum Sex { M, F, O }
    public class Client
    {
        [Key]
        public Guid Id{ get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string CI { get; set; }
        public Sex Sex { get; set; }
        public bool VIP { get; set; }
    }
}
