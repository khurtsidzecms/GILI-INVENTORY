using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Contracts
{
    public interface IUOW : IDisposable
    {
        IProductRepository Product { get; }
        IShopRepository Shop { get; }
        IShopProductRepository ShopProduct { get; }
        IDictionaryRepository Dictionary { get; }

        void Commit();
    }
}
