
using Mapster;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MiniInventory.Core.Domain;
using MiniInventory.Core.Domain.Model;
using MiniInventory.Infrastructure.Sql;

namespace MiniInventory.Core.Services;
public class ProductService : IProductService
{
    private readonly MiniInventoryContext _context;
    
    public ProductService(MiniInventoryContext context)
    {
        _context = context;
       
    }
    public async Task<List<ProductModel>> Get(CancellationToken cancellationToken)
    {
        var entities = await _context.Products.ToListAsync(cancellationToken);
        return entities.Adapt<List<ProductModel>>();
    }
    public async Task<int> GetProductStockInWarehouse(int productId, int warehouseId, CancellationToken cancellationToken)
    {
        //var stockCount= await _context.Database.ExecuteSqlInterpolatedAsync($@" SELECT dbo.GetProductStockInWarehouse ({productId},{warehouseId} )", cancellationToken);

        var stockCount = await _context.Database
            .SqlQuery<int>($"SELECT dbo.GetProductStockInWarehouse({productId},{warehouseId}) AS Value")
            .FirstOrDefaultAsync(cancellationToken);

        return stockCount;
    }
    public async Task Insert(NewProductModel model, CancellationToken cancellationToken)
    {
        await _context.Database.ExecuteSqlInterpolatedAsync(
                $@"
                dbo.AddProduct 
                @ProductName = {model.ProductName},   
                @Price = {model.Price}
                ", cancellationToken);

    }

}