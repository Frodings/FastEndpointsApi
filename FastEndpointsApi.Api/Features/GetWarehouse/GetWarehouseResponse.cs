namespace FastEndpointsApi.Features.GetWarehouse;

/// <param name="Id">Warehouse id</param>
/// <param name="Name">Warehouse name</param>
/// <param name="Location">Warehouse geo location</param>
public record GetWarehouseResponse(
    string Id,
    string Name,
    string Location
);