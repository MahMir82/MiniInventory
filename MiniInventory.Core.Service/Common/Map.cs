
using Mapster;
using MiniInventory.Core.Domain;
using MiniInventory.Core.Domain.Model;

namespace MiniInventory.Core.Services;
//public class Map : Profile
//{
//    public Map()
//    {
//        CreateMap<Product, ProductModel>().ReverseMap();
//        CreateMap<Transaction, TransactionModel>().ReverseMap();
//        CreateMap<TransactionType, TransactionTypeModel>().ReverseMap();
//        CreateMap<Warehouse, WarehouseModel>().ReverseMap();

//    }
//}


public class Map : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Product, ProductModel>();
        config.NewConfig<Product, NewProductModel>();
        config.NewConfig<Transaction, TransactionModel>();
        config.NewConfig<Transaction, NewTransactionModel>();
        config.NewConfig<TransactionType, TransactionTypeModel>();
        config.NewConfig<Warehouse, WarehouseModel>();
    }
}

