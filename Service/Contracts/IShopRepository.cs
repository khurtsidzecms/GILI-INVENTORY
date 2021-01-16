using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Contracts
{
    public interface IShopRepository : IRepositoryBase<Shop>
    {
        IEnumerable<Shop> GetAll();
    }
}
