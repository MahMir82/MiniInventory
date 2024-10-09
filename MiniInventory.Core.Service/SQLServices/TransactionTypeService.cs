
using MiniInventory.Infrastructure.Sql;

namespace MiniInventory.Core.SQLServices;
public class TransactionTypeService : ITransactionTypeService
{
    private readonly MiniInventoryContext _context;
    
    public TransactionTypeService(MiniInventoryContext context)
    {
        _context = context;
       
    }
    public async Task<List<TransactionTypeModel>> Get(CancellationToken cancellationToken)
    {
        var entities = await _context.TransactionTypes.ToListAsync(cancellationToken);
        return entities.Adapt<List<TransactionTypeModel>>();       
        // _mapper.Map<List<TransactionTypeModel>>(entities);
    }

}