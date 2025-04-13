using FastEndpoints;
using FastEndpointsApi.DataAccess.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FastEndpointsApi.Features.AddWarehouse;

/// <summary>
/// Adds a new warehouse
/// </summary>
public class AddWarehouseEndpoint : Endpoint<AddWarehouseRequest, Results<Created<AddWarehouseResponse>, BadRequest>>
{
    private readonly IWarehouseRepository _warehouseRepository;

    public AddWarehouseEndpoint(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }
    public override void Configure()
    {
        Post("warehouses/");
        AllowAnonymous(); // todo add auth for this endpoint
    }

    public override async Task<Results<Created<AddWarehouseResponse>, BadRequest>> ExecuteAsync(AddWarehouseRequest request, CancellationToken ct)
    {
        var model = MapToModel(request);
        var id = _warehouseRepository.Add(model);
        
        return TypedResults.Created($"api/warehouses/{id}", new AddWarehouseResponse(id));
    }

    private Domain.Models.Warehouse MapToModel(AddWarehouseRequest request)
    {
        return new Domain.Models.Warehouse
        {
            Name = request.Name,
            Location = request.Location
        };
    }
}