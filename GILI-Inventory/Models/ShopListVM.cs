using BLL.DTOs.Product;
using BLL.DTOs.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GILI_Inventory.Models
{
    public class ShopListVM
    {
        public IEnumerable<ShopListDTO> Shop { get; set; }

        public ShopCUComponents Components { get; set; }

        public string searchName { get; set; }

        public string searchAddress { get; set; }

        public int searchType { get; set; }
    }
}
