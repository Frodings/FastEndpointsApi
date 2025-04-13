using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace FastEndpointsApi.Features.DeleteWarehouse;

public class DeleteWarehouseEndpoint : EndpointWithoutRequest<Results<NoContent, NotFound>>
{
    public override void Configure()
    {
        Delete("warehouses/{id}");
        AllowAnonymous(); // todo add auth for this endpoint
    }

    public override Task<Results<NoContent, NotFound>> ExecuteAsync(CancellationToken ct)
    {
        throw new InvalidOperationException("Testing exception handling here..");
    }
}