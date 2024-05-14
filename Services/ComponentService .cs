using CRUD_db.Interfaces;
using CRUD_db.Models;
using Dapper;

namespace CRUD_db.Services
{
    public class ComponentService : IComponentService
    {
        private IConnectionService _connectionService;
        public ComponentService(IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public async Task AddComponent(Component newComponent)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"INSERT INTO Components (Type," +
            $"BrandId," +
            $"Model," +
            $"Specs," +
            $"Price) " +
            $"QuantityInStock) " +
            $"VALUES (@Type, @BrandId, @Model, @Specs, @Price, @QuantityInStock)";

            await connection.QueryAsync<Component>(query, newComponent);
        }

        public async Task DeleteComponent(int componentId)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"DELETE FROM Components WHERE ComponentId = {componentId}";
            await connection.QueryAsync<Component>(query);
        }

        public async Task<Component> GetById(int componentId)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = $"SELECT * FROM Components WHERE ComponentId = {componentId}";
            return await connection.QueryFirstAsync<Component>(query);
        }

        public async Task<IEnumerable<Component>> GetComponents()
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var query = "SELECT * FROM Components";
            return await connection.QueryAsync<Component>(query);
        }

        public async Task UpdateComponent(Component updatedComponent)
        {
            using var connection = _connectionService.GetConnection();
            await connection.OpenAsync();

            var componentBefore = await GetById(updatedComponent.ComponentId);
            componentBefore.Type = updatedComponent.Type ?? componentBefore.Type;
            componentBefore.BrandId = updatedComponent.BrandId ?? componentBefore.BrandId;
            componentBefore.Model = updatedComponent.Model ?? componentBefore.Model;
            componentBefore.Specs = updatedComponent.Specs ?? componentBefore.Specs;
            componentBefore.Price = updatedComponent.Price ?? componentBefore.Price;
            componentBefore.QuantityInStock = updatedComponent.QuantityInStock ?? componentBefore.QuantityInStock;

            var query = $"UPDATE Components SET Type = @Type, " +
                $"BrandId = @BrandId, " +
                $"Model = @Model, " +
                $"Specs = @Specs, " +
                $"Price = @Price " +
                $"QuantityInStock = @QuantityInStock " +
                $"WHERE ComponentId = @ComponentId";
            await connection.QueryAsync<Component>(query, updatedComponent);
        }
    }
}
