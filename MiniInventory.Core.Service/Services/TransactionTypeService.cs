


using Mapster;
using Microsoft.EntityFrameworkCore;
using MiniInventory.Core.Domain;
using MiniInventory.Core.Domain.Model;
using MiniInventory.Infrastructure.Sql;
using System.Xml.Serialization;

namespace MiniInventory.Core.Services;
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