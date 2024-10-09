
using MiniInventory.Infrastructure.Sql;

namespace MiniInventory.Core.SQLServices;
public class TransactionService : ITransactionService
{
    private readonly MiniInventoryContext _context;
    
    public TransactionService(MiniInventoryContext context)
    {
        _context = context;
       
    }
    public async Task<List<TransactionModel>> Get(CancellationToken cancellationToken)
    {
        var entities= await _context.Transactions.ToListAsync(cancellationToken);
        return entities.Adapt<List<TransactionModel>>(); 
    }

    public async Task<List<TransactionModel>> GetTransactionByTypeName(string typeName, CancellationToken cancellationToken)
    {
        
        var entities = await _context.Transactions.FromSqlInterpolated($"dbo.GetTransactionsByType {typeName}").ToListAsync(cancellationToken);
        return entities.Adapt<List<TransactionModel>>();
       
    }

    public async Task Insert(NewTransactionModel model, CancellationToken cancellationToken)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $@"  
                dbo.AddTransaction  
                @ProductId = {model.ProductId},   
                @WarehouseId = {model.WarehouseId},   
                @Quantity = {model.Quantity},
                @TransactionTypeName = {model.TransactionTypeName}                               
            ", cancellationToken);

        
    }

}