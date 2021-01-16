using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.Product;
using BLL.Interfaces;
using GILI_Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GILI_Inventory.Controllers
{
    public class ShopController : Controller
    {
        private readonly IShopOperation _shopOperation;

        public ShopController(IShopOperation shopOperation)
        {
            _shopOperation = shopOperation;
        }

        public IActionResult Index()
        {
            ShopListVM model = new ShopListVM()
            {
                Shop = _shopOperation.GetAll().OrderByDescending(e => e.Id)
            };

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

            _shopOperation.UpdateShop(model.Shop);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int Id)
        {

            ShopCUDTO Shop = _shopOperation.GetShop(Id);

            _shopOperation.DeleteShop(Shop);

            return RedirectToAction(nameof(Index));
        }

        private ShopCUVM GetCreateShopModel(ShopCUDTO shop)
        {
            ShopCUVM model = new ShopCUVM()
            {
                Components = _shopOperation.GetShopFormComponents(),
                Shop = shop
            };

            return model;
        }

        private ShopCUVM GetUpdateShopModel(ShopCUDTO shop)
        {
            ShopCUVM model = new ShopCUVM()
            {
                Components = _shopOperation.GetShopFormComponents(),
                Shop = shop
            };

            return model;
        }

    }
}