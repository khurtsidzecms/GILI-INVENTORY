using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Contracts
{
    public interface IShopRepository : IRepositoryBase<Shop>
    {
        IEnumerable<Shop> GetAll();
        IEnumerable<ShopProduct> GetProductAll(int Id);

        IEnumerable<Shop> SearchAll(string searchName, string searchAddress, int? searchType);

        Shop GetShop(int Id);

        public void DeleteProducts(int ShopId);
    }
}
