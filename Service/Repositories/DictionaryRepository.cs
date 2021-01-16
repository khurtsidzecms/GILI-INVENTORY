using DAL.Context;
using DAL.Entities;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Service.Repositories
{
    public class DictionaryRepository : RepositoryBase<Dictionary>, IDictionaryRepository
    {
        public DictionaryRepository(InventoryDbContext context)
            : base(context)
        { }

        public IEnumerable<Dictionary> GetShopFormComponents()
        {
            bool yes = true;
            return FindByCondition(x => yes);
        }
    }
}
