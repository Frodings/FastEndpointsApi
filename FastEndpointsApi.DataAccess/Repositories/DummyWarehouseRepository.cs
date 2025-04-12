

using FastEndpointsApi.DataAccess.Models;

namespace FastEndpointsApi.DataAccess.Repositories;

public class DummyWarehouseRepository : IWarehouseRepository
{
    private readonly List<Models.Warehouse> _warehouses = new()
    {
        new Warehouse { Id = 1, Name = "Main Warehouse", Location = "New York" },
        new Warehouse { Id = 2, Name = "Backup Warehouse", Location = "Los Angeles" }
    };

    public IEnumerable<Warehouse> GetAll() => _warehouses;

    public Warehouse? GetById(int id) => _warehouses.FirstOrDefault(w => w.Id == id);

    public void Add(Warehouse warehouse)
    {
        warehouse.Id = _warehouses.Max(w => w.Id) + 1;
        _warehouses.Add(warehouse);
    }

    public void Update(Warehouse warehouse)
    {
        var existing = GetById(warehouse.Id);
        if (existing is null) return;
        existing.Name = warehouse.Name;
        existing.Location = warehouse.Location;
    }

    public void Delete(int id)
    {
        var warehouse = GetById(id);
        if (warehouse is not null)
            _warehouses.Remove(warehouse);
    }
}