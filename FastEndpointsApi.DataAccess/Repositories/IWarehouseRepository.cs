using FastEndpointsApi.Domain.Models;

namespace FastEndpointsApi.DataAccess.Repositories;

public interface IWarehouseRepository
{
    IEnumerable<Warehouse> GetAll();
    Task<Warehouse?> GetById(string id);
    void Add(Warehouse warehouse);
    void Update(Warehouse warehouse);
    void Delete(int id);
}