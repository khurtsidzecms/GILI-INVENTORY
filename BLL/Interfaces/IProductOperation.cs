using BLL.DTOs.Product;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface IProductOperation
    {
        public IEnumerable<ProductListDTO> GetAll();

        public IEnumerable<ProductListDTO> SearchAll(string searchName, string searchCode, string searchBrand);

        public ProductCUDTO GetProduct(int Id);

        public void CreateProduct(ProductCUDTO model);

        public void UpdateProduct(ProductCUDTO model);

        public void DeleteProduct(ProductCUDTO model);
    }
}
