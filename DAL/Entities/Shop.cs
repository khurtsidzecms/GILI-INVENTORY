using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public int TypeId { get; set; }

        public ICollection<ShopProduct> ShopProducts { get; set; }

        public Dictionary Type { get; set; }
    }
}
