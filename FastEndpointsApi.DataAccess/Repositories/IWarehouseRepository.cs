using FastEndpointsApi.DataAccess.Models;

namespace FastEndpointsApi.DataAccess.Repositories;

public interface IWarehouseRepository
{
    IEnumerable<Warehouse> GetAll();
    Warehouse? GetById(int id);
    void Add(Warehouse warehouse);
    void Update(Warehouse warehouse);
    void Delete(int id);
}