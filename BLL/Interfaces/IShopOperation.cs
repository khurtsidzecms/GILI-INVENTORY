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

        public ShopCUDTO GetShop(int Id);

        ShopCUComponents GetShopFormComponents();

        public void CreateShop(ShopCUDTO model);

        public void UpdateShop(ShopCUDTO model);

        public void DeleteShop(ShopCUDTO model);
    }
}
