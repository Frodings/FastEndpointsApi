using FastEndpointsApi.Domain.Models;

namespace FastEndpointsApi.DataAccess.Repositories;

public class DummyWarehouseRepository : IWarehouseRepository
{
    private readonly List<Warehouse> _warehouses = new()
    {
        new Warehouse { Id = "1", Name = "Hovedvarehus", Location = "New York" },
        new Warehouse { Id = "2", Name = "Sekundært varehus", Location = "Los Angeles" }
    };

    public IEnumerable<Warehouse> GetAll() => _warehouses;

    public async Task<Warehouse?> GetById(string id)
    {
        var warehouse = _warehouses.FirstOrDefault(w => w.Id == id);
        return warehouse;
    }

    public void Add(Warehouse warehouse)
    {
        warehouse.Id = _warehouses.Max(w => w.Id) + 1;
        _warehouses.Add(warehouse);
    }

    public void Update(Warehouse warehouse)
    {
        // var existing = GetById(warehouse.Id);
        // if (existing is null) return;
        // existing.Name = warehouse.Name;
        // existing.Location = warehouse.Location;
    }

    public void Delete(int id)
    {
        // var warehouse = GetById(id);
        // if (warehouse is not null)
        //     _warehouses.Remove(warehouse);
    }
}