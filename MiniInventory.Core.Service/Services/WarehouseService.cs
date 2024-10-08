


using Mapster;
using Microsoft.EntityFrameworkCore;
using MiniInventory.Core.Domain;
using MiniInventory.Core.Domain.Model;
using MiniInventory.Infrastructure.Sql;

namespace MiniInventory.Core.Services;
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
        await _context.Database.ExecuteSqlInterpolatedAsync(
               $@"
                dbo.AddWarehouse 
                @WarehouseName = {model.WarehouseName},   
                @Location = {model.Location}
                ", cancellationToken);
    }
}