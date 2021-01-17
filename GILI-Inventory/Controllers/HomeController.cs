using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GILI_Inventory.Models;
using Service.Contracts;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace GILI_Inventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductOperation _productOperation;

        private readonly IShopOperation _shopOperation;

        public HomeController(
            ILogger<HomeController> logger,
            IProductOperation productOperation,
            IShopOperation shopOperation)
        {
            _logger = logger;
            _productOperation = productOperation;
            _shopOperation = shopOperation;
        }

        [Authorize]
        public IActionResult Index()
        {
            ProductListVM model = new ProductListVM()
            {
                Products = _productOperation.GetAll().Take(3)
            };

            ViewBag.countProducts = _productOperation.GetAll().Count();
            ViewBag.countShops    = _shopOperation.GetAll().Count();

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
