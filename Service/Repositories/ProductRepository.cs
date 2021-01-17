using DAL.Context;
using DAL.Entities;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Service.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(InventoryDbContext context)
            : base(context)
        { }

        public IEnumerable<Product> GetAll()
        {
            return Context.Product;
        }

        public IEnumerable<Product> SearchAll(string searchName, string searchCode, string searchBrand)
        {
            if (!string.IsNullOrEmpty(searchName) || !string.IsNullOrEmpty(searchCode) || !string.IsNullOrEmpty(searchBrand))
            {
                return Context.Product.Where(x => x.Name.Contains(searchName) ||
                                                  x.Code.Contains(searchCode) ||
                                                  x.Brand.Contains(searchBrand));
            }
            else
            {
                return Context.Product;
            }
        }

        public Product GetProduct(int Id)
        {
            return Context.Product.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
