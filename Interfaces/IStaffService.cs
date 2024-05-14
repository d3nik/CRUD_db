using CRUD_db.Models;

namespace CRUD_db.Interfaces
{
    public interface IStaffService
    {
        Task<IEnumerable<Staff>> GetStaff();
        Task<Staff> GetById(int staffId);
        Task AddStaff(Staff newStaff);
        Task UpdateStaff(Staff newStaff);
        Task DeleteStaff(int staffId);
    }
}
