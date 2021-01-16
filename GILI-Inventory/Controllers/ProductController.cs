using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTOs.Product;
using BLL.Interfaces;
using GILI_Inventory.Models;
using Microsoft.AspNetCore.Mvc;

namespace GILI_Inventory.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductOperation _productOperation;

        public ProductController(IProductOperation productOperation)
        {
            _productOperation = productOperation;
        }

        public IActionResult Index()
        {
            ProductListVM model = new ProductListVM()
            {
                Products = _productOperation.GetAll().OrderByDescending(e => e.Id)
            };

            return View(model);
        }

        public IActionResult Create()
        {
            var model = GetCreateProductModel(new ProductCUDTO());
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ProductCUVM model)
        {
            if(!ModelState.IsValid)
            {
                return View(GetCreateProductModel(model.Product));
            }

            _productOperation.CreateProduct(model.Product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int Id)
        {
            ProductCUDTO Product = _productOperation.GetProduct(Id);
            var model = GetUpdateProductModel(Product);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ProductCUVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(GetUpdateProductModel(model.Product));
            }

            _productOperation.UpdateProduct(model.Product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Detail(int Id)
        {

            ProductCUDTO model = _productOperation.GetProduct(Id);

            return View(model);
        }

        public IActionResult Delete(int Id)
        {

            ProductCUDTO Product = _productOperation.GetProduct(Id);

            _productOperation.DeleteProduct(Product);

            return RedirectToAction(nameof(Index));
        }

        private ProductCUVM GetCreateProductModel(ProductCUDTO product)
        {
            ProductCUVM model = new ProductCUVM()
            {
                Product = product
            };

            return model;
        }

        private ProductCUVM GetUpdateProductModel(ProductCUDTO product)
        {
            ProductCUVM model = new ProductCUVM()
            {
                Product = product
            };

            return model;
        }

    }
}