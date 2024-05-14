using CRUD_db.Models;

namespace CRUD_db.Interfaces
{
    public interface IComponentService
    {
        Task<IEnumerable<Component>> GetComponents();
        Task<Component> GetById(int componentId);
        Task AddComponent(Component newComponent);
        Task UpdateComponent(Component newComponent);
        Task DeleteComponent(int componentId);
    }
}
