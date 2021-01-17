using System.Collections.Generic;
using BLL.DTOs.Product;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.DTOs.Shop
{
    public class ShopCUComponents
    {
        public List<SelectListItem> Types { get; set; }
        public IEnumerable<ProductListDTO> Products { get; set; }
    }
}
