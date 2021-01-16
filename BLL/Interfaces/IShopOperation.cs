using BLL.DTOs.Product;
using BLL.DTOs.Shop;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IShopOperation
    {
        public IEnumerable<ShopListDTO> GetAll();

        ShopCUComponents GetShopFormComponents();

        public void CreateShop(ShopCUDTO model);
    }
}
