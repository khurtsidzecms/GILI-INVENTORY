using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.Product;
using BLL.DTOs.Shop;
using BLL.Interfaces;
using GILI_Inventory.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GILI_Inventory.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly IShopOperation _shopOperation;

        private readonly IProductOperation _productOperation;

        public ShopController(
            IShopOperation shopOperation,
            IProductOperation productOperation
        )
        {
            _shopOperation = shopOperation;
            _productOperation = productOperation;
        }

        public IActionResult Index()
        {
            ShopListVM model = new ShopListVM()
            {
                Shop = _shopOperation.GetAll().OrderByDescending(e => e.Id),
                Components = _shopOperation.GetShopFormComponents()
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(string searchName, string searchAddress, int searchType)
        {
            ShopListVM model = new ShopListVM()
            {
                Shop = _shopOperation.SearchAll(searchName, searchAddress, searchType).OrderByDescending(e => e.Id),
                Components = _shopOperation.GetShopFormComponents()
            };

            ViewBag.searchName = searchName;
            ViewBag.searchAddress = searchAddress;
            ViewBag.searchType = searchType;

            return View(model);
        }

        public IActionResult Create()
        {
            var model = GetCreateShopModel(new ShopCUDTO());
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ShopCUVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(GetCreateShopModel(model.Shop));
            }

            _shopOperation.CreateShop(model.Shop);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            ShopCUDTO Shop = _shopOperation.GetShop(Id);
            var model = GetUpdateShopModel(Shop);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ShopCUVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(GetUpdateShopModel(model.Shop));
            }

            _shopOperation.DeleteProducts(model.Shop.Id);

            _shopOperation.UpdateShop(model.Shop);

            var viewModel = GetUpdateShopModel(model.Shop);
            ViewBag.Message = "მაღაზია წარმატებით განახლდა!";
            return View(viewModel);
        }

        public IActionResult Delete(int Id)
        {

            ShopCUDTO Shop = _shopOperation.GetShop(Id);

            _shopOperation.DeleteShop(Shop);

            return RedirectToAction(nameof(Index));
        }

        private ShopCUVM GetCreateShopModel(ShopCUDTO shop)
        {
            IEnumerable<ProductListDTO> Products = _productOperation.GetAll();

            ShopCUVM model = new ShopCUVM()
            {
                Components = _shopOperation.GetShopFormComponents(),
                Shop = shop,
                Products = Products
            };

            return model;
        }

        private ShopCUVM GetUpdateShopModel(ShopCUDTO shop)
        {
            IEnumerable<ProductListDTO> Products = _productOperation.GetAll();

            IEnumerable<ShopProductDTO> ShopProducts = _shopOperation.GetProductAll(shop.Id);

            ShopCUVM model = new ShopCUVM()
            {
                Components = _shopOperation.GetShopFormComponents(),
                Shop = shop,
                Products = Products,
                ShopProducts = ShopProducts
            };

            return model;
        }

    }
}