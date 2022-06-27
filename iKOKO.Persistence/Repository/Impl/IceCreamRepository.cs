using iKOKO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iKOKO.Persistence.Repository
{
    public class IceCreamRepository : GenericRepository<IceCream>, IIceCreamRepository
    {
        public IceCreamRepository(iKOKODbContext context) : base(context)
        {
        }
    }
}
