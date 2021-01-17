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

        public IEnumerable<ShopProductDTO> GetProductAll(int Id)
        {
            var shops = _uow.Shop.GetProductAll(Id);

            return _mapper.Map<IEnumerable<ShopProductDTO>>(shops);
        }

        public IEnumerable<ShopListDTO> SearchAll(string searchName, string searchAddress, int searchType)
        {
            var shops = _uow.Shop.SearchAll(searchName, searchAddress, searchType);

            return _mapper.Map<IEnumerable<ShopListDTO>>(shops);
        }

        public ShopCUComponents GetShopFormComponents()
        {
            var dictionaries = _uow.Dictionary.GetShopFormComponents();
            ShopCUComponents model = new ShopCUComponents();
            model.Types = dictionaries.Select(x => new SelectListItem() { Text = x.Name, Value = x.Id.ToString() }).ToList();
            return model;
        }

        public ShopCUDTO GetShop(int Id)
        {
            var shop = _uow.Shop.GetShop(Id);

            return _mapper.Map<ShopCUDTO>(shop);
        }

        public void CreateShop(ShopCUDTO model)
        {
            var shop = _mapper.Map<Shop>(model);
            _uow.Shop.Create(shop);
            _uow.Commit();
        }

        public void UpdateShop(ShopCUDTO model)
        {
            var dbShop = _uow.Shop.GetShop(model.Id);
            _mapper.Map<ShopCUDTO, Shop>(model, dbShop);
            _uow.Shop.Update(dbShop);
            _uow.Commit();
        }

        public void DeleteProducts(int Id)
        {
            _uow.Shop.DeleteProducts(Id);
            _uow.Commit();
        }

        public void DeleteShop(ShopCUDTO model)
        {
            var dbShop = _uow.Shop.GetShop(model.Id);
            _mapper.Map<ShopCUDTO, Shop>(model, dbShop);
            _uow.Shop.Delete(dbShop);
            _uow.Commit();
        }
    }
}
