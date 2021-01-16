using BLL.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GILI_Inventory.Models
{
    public class ProductListVM
    {
        public IEnumerable<ProductListDTO> Products { get; set; }
    }
}
