using MiniInventory.Core.Domain.Model;

namespace MiniInventory.Core.Domain;
public interface IProductService
{
    Task<List<ProductModel>> Get(CancellationToken cancellationToken);
    Task<int> GetProductStockInWarehouse(int productId, int warehouseId, CancellationToken cancellationToken);
    Task Insert(NewProductModel model, CancellationToken cancellationToken);
}