using AutoMapper;
using BLL.DTOs.Product;
using BLL.Interfaces;
using DAL.Entities;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Operations
{
    public class ProductOperation : IProductOperation
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public ProductOperation(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public IEnumerable<ProductListDTO> GetAll()
        {
            var products = _uow.Product.GetAll();

            return _mapper.Map<IEnumerable<ProductListDTO>>(products);
        }

        public IEnumerable<ProductListDTO> SearchAll(string searchName, string searchCode, string searchBrand)
        {
            var products = _uow.Product.SearchAll(searchName, searchCode, searchBrand);

            return _mapper.Map<IEnumerable<ProductListDTO>>(products);
        }

        public ProductCUDTO GetProduct(int Id)
        {
            var product = _uow.Product.GetProduct(Id);

            return _mapper.Map<ProductCUDTO>(product);
        }

        public void CreateProduct(ProductCUDTO model)
        {
            var product = _mapper.Map<Product>(model);
            _uow.Product.Create(product);
            _uow.Commit();
        }

        public void UpdateProduct(ProductCUDTO model)
        {
            var dbProduct = _uow.Product.GetProduct(model.Id);
            _mapper.Map<ProductCUDTO, Product>(model, dbProduct);
            _uow.Product.Update(dbProduct);
            _uow.Commit();
        }

        public void DeleteProduct(ProductCUDTO model)
        {
            var dbProduct = _uow.Product.GetProduct(model.Id);
            _mapper.Map<ProductCUDTO, Product>(model, dbProduct);
            _uow.Product.Delete(dbProduct);
            _uow.Commit();
        }
    }
}
