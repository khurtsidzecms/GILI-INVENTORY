using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ShopProduct
    {
        public int Id { get; set; }

        public float Price { get; set; }

        public int Barcode { get; set; }

        public int ShopId { get; set; }

        public int ProductId { get; set; }

        public Shop Shop { get; set; }

        public Product Product { get; set; }

    }
}
