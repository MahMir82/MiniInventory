
using MiniInventory.Core.Domain;
using MiniInventory.Infrastructure.EF;

namespace MiniInventory.Core.EFServices;
public class WarehouseService : IWarehouseService
{
    private readonly MiniInventoryContext _context;
    
    public WarehouseService(MiniInventoryContext context)
    {
        _context = context;
       
    }
    public async Task<List<WarehouseModel>> Get(CancellationToken cancellationToken)
    {
        var entities = await _context.Warehouses.ToListAsync(cancellationToken);
        return entities.Adapt<List<WarehouseModel>>();
    }

    public async Task Insert(WarehouseModel model, CancellationToken cancellationToken)
    {
        var entity=model.Adapt<Warehouse>();
        _context.Warehouses.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
       
    }
}