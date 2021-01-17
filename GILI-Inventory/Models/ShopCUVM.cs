using BLL.DTOs.Product;
using BLL.DTOs.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GILI_Inventory.Models
{
    public class ShopCUVM
    {
        public ShopCUDTO Shop { get; set; }

        public IEnumerable<ProductListDTO> Products { get; set; }

        public IEnumerable<ShopProductDTO> ShopProducts { get; set; }

        public ShopCUComponents Components { get; set; }
    }
}
