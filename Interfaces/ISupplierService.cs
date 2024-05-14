using CRUD_db.Models;

namespace CRUD_db.Interfaces
{
    public interface ISupplierService
    {
        Task<IEnumerable<Supplier>> GetSuppliers();
        Task<Supplier> GetById(int supplierId);
        Task AddSupplier(Supplier newSupplier);
        Task UpdateSupplier(Supplier newSupplier);
        Task DeleteSupplier(int supplierId);
    }
}
