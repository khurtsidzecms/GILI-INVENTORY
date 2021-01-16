using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repositories
{
    public class ShopRepository : RepositoryBase<Shop>, IShopRepository
    {
        public ShopRepository(InventoryDbContext context)
            : base(context)
        { }

        public IEnumerable<Shop> GetAll()
        {
            return Context.Shop.Include(e => e.Type);
        }
    }
}
