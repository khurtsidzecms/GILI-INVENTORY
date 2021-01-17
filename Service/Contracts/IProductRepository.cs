using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IEnumerable<Product> GetAll();

        IEnumerable<Product> SearchAll(string searchName, string searchCode, string searchBrand);

        Product GetProduct(int Id);
    }
}
