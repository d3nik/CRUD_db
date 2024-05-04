using CRUD_db.Models;

namespace CRUD_db.Interfaces
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetById(int customerId);
        Task AddCustomer(Customer newCustomer);
        Task UpdateCustomer(Customer newCustomer);
        Task DeleteCustomer(int customerId);
    }
}
