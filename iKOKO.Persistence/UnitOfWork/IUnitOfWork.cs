using iKOKO.Persistence.Repository;
using System;
using System.Threading.Tasks;

namespace iKOKO.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ISaleRepository SaleRepository { get; set; }
        IIceCreamRepository IceCreamRepository { get; set; }
        IClientRepository ClientRepository { get; set; }
        IProductRepository ProductRepository { get; set; }
        IWarehouseRepository WarehouseRepository { get; set; }
        Task<int> SaveChangesAsync();
    }
}
