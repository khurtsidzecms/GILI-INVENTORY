using BLL.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IProductOperation
    {
        public IEnumerable<ProductListDTO> GetAll();

        public void CreateProduct(ProductCUDTO model);
    }
}
