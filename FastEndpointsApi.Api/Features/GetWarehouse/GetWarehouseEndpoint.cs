using FastEndpoints;
using FastEndpointsApi.DataAccess.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FastEndpointsApi.Features.GetWarehouse;

public class GetWarehouseEndpoint : EndpointWithoutRequest<Results<Ok<GetWarehouseResponse>,NotFound>>
{
    private readonly IWarehouseRepository _warehouseRepository;

    public GetWarehouseEndpoint(IWarehouseRepository warehouseRepository)
    {
        _warehouseRepository = warehouseRepository;
    }

    public override void Configure()
    {
        Get("/api/warehouses/{id}");
        AllowAnonymous();
    }

    public override async Task<Results<Ok<GetWarehouseResponse>, NotFound>> ExecuteAsync(CancellationToken ct)
    {
        var warehouse = await _warehouseRepository.GetById(Route<string>("id")!);
        
        if (warehouse is null)
            return TypedResults.NotFound();

        var response = MapToResponse(warehouse);
        return TypedResults.Ok(response);
    }

    private GetWarehouseResponse MapToResponse(Domain.Models.Warehouse model)
    {
        return new GetWarehouseResponse(model.Id, model.Name, model.Location);
    }
}