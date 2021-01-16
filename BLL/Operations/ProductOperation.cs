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

        public void CreateProduct(ProductCUDTO model)
        {
            var product = _mapper.Map<Product>(model);
            _uow.Product.Create(product);
            _uow.Commit();
        }
    }
}
