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

        public Product GetProduct(int Id)
        {
            return Context.Product.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
