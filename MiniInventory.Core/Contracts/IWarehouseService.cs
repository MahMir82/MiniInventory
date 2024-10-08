using MiniInventory.Core.Domain.Model;

namespace MiniInventory.Core.Domain;
public interface IWarehouseService
{
    Task<List<WarehouseModel>> Get(CancellationToken cancellationToken);
    Task Insert(WarehouseModel model, CancellationToken cancellationToken);
}