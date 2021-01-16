using BLL.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GILI_Inventory.Models
{
    public class ShopListVM
    {
        public IEnumerable<ShopListDTO> Shop { get; set; }
    }
}
