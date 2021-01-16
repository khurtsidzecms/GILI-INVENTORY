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

        private ProductCUVM GetCreateProductModel(ProductCUDTO product)
        {
            ProductCUVM model = new ProductCUVM()
            {
                Product = product
            };

            return model;
        }

    }
}