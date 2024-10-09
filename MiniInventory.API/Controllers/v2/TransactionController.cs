using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MiniInventory.Core.Domain;
using MiniInventory.Core.Domain.Model;

namespace MiniInventory.API.Controllers.v2;

[ApiVersion("2")]

public class TransactionController : BaseController
{
    private readonly ITransactionService _transactionService;
    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        return Ok(await _transactionService.Get(cancellationToken));
    }

    [HttpGet("{typeName}")]
    public async Task<IActionResult> GetTransactionByTypeName(string typeName, CancellationToken cancellationToken)
    {
        return Ok(await _transactionService.GetTransactionByTypeName(typeName, cancellationToken));
    }


    [HttpPost]
    public async Task<IActionResult> Insert(NewTransactionModel model, CancellationToken cancellationToken)
    {
        await _transactionService.Insert(model, cancellationToken);
        return Ok();
    }
}



