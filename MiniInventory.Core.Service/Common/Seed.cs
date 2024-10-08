﻿using MiniInventory.Infrastructure.Sql;

namespace MiniInventory.Core.Services;

public class DataSeeder
{
    private readonly MiniInventoryContext _context;

    public DataSeeder(MiniInventoryContext context)
    {
        _context = context;
    }

    public void Seed()
    {
        if (!_context.TransactionTypes.Any())
        {
            var items = new List<TransactionType>
            {
                new TransactionType { TransactionTypeId = 1, TransactionTypeName = "Purchase",Multiplier=1 },
                new TransactionType { TransactionTypeId = 2, TransactionTypeName = "Sale",Multiplier=-1 },
                new TransactionType { TransactionTypeId = 3, TransactionTypeName = "Return",Multiplier=1 },
                            };

            _context.TransactionTypes.AddRange(items);

            var itemsWarehouse = new List<Warehouse>
            {
                new Warehouse {  WarehouseName = "Warehouse No.1",Location="Tehran" },
                new Warehouse {  WarehouseName = "Warehouse No.2",Location="Isfahan"  },
                new Warehouse {  WarehouseName = "Warehouse No.3",Location="Shiraz"  },
                            };

            _context.Warehouses.AddRange(itemsWarehouse);
            _context.SaveChanges();
        }

    }
}
