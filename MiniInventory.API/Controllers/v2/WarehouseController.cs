using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MiniInventory.Core.Domain;
using MiniInventory.Core.Domain.Model;

namespace MiniInventory.API.Controllers.v2;
[ApiVersion("2")]
public class WarehouseController : BaseController
{
    private readonly IWarehouseService _warehouseService;
    public WarehouseController(IWarehouseService warehouseService)
    {
        _warehouseService = warehouseService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await _warehouseService.Get(cancellationToken));
    }
    [HttpPost]
    public async Task<IActionResult> Insert(WarehouseModel model,CancellationToken cancellationToken)
    {
        await _warehouseService.Insert(model, cancellationToken);
        return Ok();
    }
}



