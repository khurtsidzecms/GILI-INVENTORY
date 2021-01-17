using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs.Shop
{
    public class ShopProductDTO
    {
        [Required]
        public float Price { get; set; }

        public int? Barcode { get; set; }

        [Required]
        public int ProductId { get; set; }
    }
}
