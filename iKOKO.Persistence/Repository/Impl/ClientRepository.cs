using iKOKO.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iKOKO.Persistence.Repository
{
     public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(iKOKODbContext context) : base(context)
        {
        }
    }
}
