
using MiniInventory.Infrastructure.EF;


namespace MiniInventory.Core.EFServices;
public class TransactionService : ITransactionService
{
    private readonly MiniInventoryContext _context;

    public TransactionService(MiniInventoryContext context)
    {
        _context = context;

    }
    public async Task<List<TransactionModel>> Get(CancellationToken cancellationToken)
    {
        var entities = await _context.Transactions.ToListAsync(cancellationToken);
        return entities.Adapt<List<TransactionModel>>();
    }

    public async Task<List<TransactionModel>> GetTransactionByTypeName(string typeName, CancellationToken cancellationToken)
    {
        var entities = await _context.Transactions.Where(a => a.TransactionTypeName == typeName).ToListAsync(cancellationToken);
        return entities.Adapt<List<TransactionModel>>();
    }

    public async Task Insert(NewTransactionModel model, CancellationToken cancellationToken)
    {
        var transactionType = await _context.TransactionTypes.FirstOrDefaultAsync(t => t.TransactionTypeName == model.TransactionTypeName, cancellationToken);
        if (transactionType != null)
        {
            var entity = model.Adapt<Transaction>();
            entity.Multiplier = transactionType.Multiplier;


            var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == model.ProductId, cancellationToken);
            if (product != null)
            {
                product.StockQuantity += transactionType.Multiplier * model.Quantity;
            }

            _context.Transactions.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
        }


    }

}