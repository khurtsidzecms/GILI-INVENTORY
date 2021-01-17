using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<ShopProduct> GetProductAll(int Id)
        {
            return Context.ShopProducts.Where(x => x.ShopId == Id);
        }

        public IEnumerable<Shop> SearchAll(string searchName, string searchAddress, int? searchType)
        {
            if (!string.IsNullOrEmpty(searchName) || !string.IsNullOrEmpty(searchAddress) || searchType != 0)
            {
                return Context.Shop.Include(e => e.Type).Where(x => x.Name.Contains(searchName) ||
                                                  x.Address.Contains(searchAddress) ||
                                                  x.TypeId == searchType);
            }
            else
            {
                return Context.Shop.Include(e => e.Type);
            }
        }

        public Shop GetShop(int Id)
        {
            return Context.Shop.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void DeleteProducts(int ShopId)
        {
            IEnumerable<ShopProduct> products = Context.ShopProducts.Where(x => x.ShopId == ShopId);

            foreach(var item in products)
            {
                Context.ShopProducts.Remove(item);
            }
        }
    }
}
