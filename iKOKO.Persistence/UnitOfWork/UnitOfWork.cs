using iKOKO.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iKOKO.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed;
        private readonly iKOKODbContext _context;

        public ISaleRepository SaleRepository { get; set; }
        public IIceCreamRepository IceCreamRepository { get; set; }
        public IClientRepository ClientRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public IWarehouseRepository WarehouseRepository { get; set; }

        public UnitOfWork(iKOKODbContext context,
            ISaleRepository saleRepository,
            IIceCreamRepository iceCreamRepository,
            IClientRepository clientRepository,
            IProductRepository productRepository,
            IWarehouseRepository warehouseRepository)
        {
            _context = context;
            SaleRepository = saleRepository;
            IceCreamRepository = iceCreamRepository;
            ClientRepository = clientRepository;
            ProductRepository = productRepository;
            WarehouseRepository = warehouseRepository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
