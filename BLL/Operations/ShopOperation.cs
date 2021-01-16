using AutoMapper;
using BLL.DTOs.Product;
using BLL.DTOs.Shop;
using BLL.Interfaces;
using DAL.Entities;
using Service.Contracts;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BLL.Operations
{
    public class ShopOperation : IShopOperation
    {
        private readonly IUOW _uow;
        private readonly IMapper _mapper;

        public ShopOperation(IUOW uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public IEnumerable<ShopListDTO> GetAll()
        {
            var shops = _uow.Shop.GetAll();

            return _mapper.Map<IEnumerable<ShopListDTO>>(shops);
        }

        public ShopCUComponents GetShopFormComponents()
        {
            var dictionaries = _uow.Dictionary.GetShopFormComponents();
            ShopCUComponents model = new ShopCUComponents();
            model.Types = dictionaries.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return model;
        }

        public void CreateShop(ShopCUDTO model)
        {
            var shop = _mapper.Map<Shop>(model);
            _uow.Shop.Create(shop);
            _uow.Commit();
        }
    }
}
