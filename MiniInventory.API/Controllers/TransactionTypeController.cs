using Microsoft.AspNetCore.Mvc;
using MiniInventory.Core.Domain;

namespace MiniInventory.API.Controllers;

public class TransactionTypeController : BaseController
{
    private readonly ITransactionTypeService _transactionTypeService;
    public TransactionTypeController(ITransactionTypeService transactionTypeService)
    {
        _transactionTypeService = transactionTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await _transactionTypeService.Get(cancellationToken));
    }

}



