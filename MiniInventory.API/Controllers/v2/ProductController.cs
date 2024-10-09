using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MiniInventory.Core.Domain;
using MiniInventory.Core.Domain.Model;

namespace MiniInventory.API.Controllers.v2;

[ApiVersion("2")]
public class ProductController : BaseController
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await _productService.Get(cancellationToken));
    }
    [HttpGet("{productId}/warehouse/{warehouseId}")]
    public async Task<IActionResult> Get(int productId, int warehouseId, CancellationToken cancellationToken)
    {
        return Ok(await _productService.GetProductStockInWarehouse(productId, warehouseId,cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> Insert(NewProductModel model,CancellationToken cancellationToken)
    {
        await _productService.Insert(model, cancellationToken);
        return Ok();
    }
}



