using FastEndpointsApi.Domain.Models;

namespace FastEndpointsApi.DataAccess.Repositories;

public class DummyWarehouseRepository : IWarehouseRepository
{
    private readonly List<Warehouse> _warehouses = new()
    {
        new Warehouse { Id = "1", Name = "Hovedvarehus", Location = "Oslo" },
        new Warehouse { Id = "2", Name = "Sekundært varehus", Location = "Bodø" }
    };

    public IEnumerable<Warehouse> GetAll() => _warehouses;

    public async Task<Warehouse?> GetById(string id)
    {
        var warehouse = _warehouses.FirstOrDefault(w => w.Id == id);
        return warehouse;
    }

    public string Add(Warehouse warehouse)
    {
        // normally would be mapped to storage model and then persisted
        
        warehouse.Id = _warehouses.Max(w => w.Id) + 1;
        _warehouses.Add(warehouse);

        return warehouse.Id;
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