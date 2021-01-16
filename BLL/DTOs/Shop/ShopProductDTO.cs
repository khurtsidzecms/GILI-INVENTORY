using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs.Shop
{
    public class ShopProductDTO
    {
        public int Id { get; set; }

        public float Price { get; set; }

        public int Barcode { get; set; }

        public int ShopId { get; set; }

        public int ProductId { get; set; }
    }
}
