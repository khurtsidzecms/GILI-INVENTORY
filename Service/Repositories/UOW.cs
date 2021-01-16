using DAL.Context;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Repositories
{
    public class UOW : IUOW
    {
        private InventoryDbContext _context { get; set; }

        private IProductRepository _productRepository;

        private IShopRepository _shopRepository;

        private IShopProductRepository _shopProductRepository;

        private IDictionaryRepository _dictionaryRepository;

        public UOW(InventoryDbContext context)
        {
            _context = context;
        }

        public IProductRepository Product
        {
            get
            {
                if (_productRepository == null)
                    _productRepository = new ProductRepository(_context);
                return _productRepository;
            }
        }

        public IShopRepository Shop
        {
            get
            {
                if (_shopRepository == null)
                    _shopRepository = new ShopRepository(_context);
                return _shopRepository;
            }
        }

        public IShopProductRepository ShopProduct
        {
            get
            {
                if (_shopProductRepository == null)
                    _shopProductRepository = new ShopProductRepository(_context);
                return _shopProductRepository;
            }
        }

        public IDictionaryRepository Dictionary
        {
            get
            {
                if (_dictionaryRepository == null)
                    _dictionaryRepository = new DictionaryRepository(_context);
                return _dictionaryRepository;
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
