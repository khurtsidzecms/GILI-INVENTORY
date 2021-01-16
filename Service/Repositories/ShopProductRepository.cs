using DAL.Context;
using DAL.Entities;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Repositories
{
    public class ShopProductRepository : RepositoryBase<ShopProduct>, IShopProductRepository
    {
        public ShopProductRepository(InventoryDbContext context)
            : base(context)
        { }
    }
}
