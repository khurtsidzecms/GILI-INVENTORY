using BLL.DTOs.Product;
using BLL.DTOs.Shop;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IShopOperation
    {
        public IEnumerable<ShopListDTO> GetAll();

        public IEnumerable<ShopProductDTO> GetProductAll(int Id);

        public IEnumerable<ShopListDTO> SearchAll(string searchName, string searchAddress, int searchType);

        public ShopCUDTO GetShop(int Id);

        ShopCUComponents GetShopFormComponents();

        public void CreateShop(ShopCUDTO model);

        public void UpdateShop(ShopCUDTO model);

        public void DeleteProducts(int Id);

        public void DeleteShop(ShopCUDTO model);
    }
}
