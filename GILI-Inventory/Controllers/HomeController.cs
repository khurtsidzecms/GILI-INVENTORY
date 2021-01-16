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

namespace GILI_Inventory.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IProductOperation _productOperation;

        public HomeController(ILogger<HomeController> logger, IProductOperation productOperation)
        {
            _logger = logger;
            _productOperation = productOperation;
        }

        public IActionResult Index()
        {
            ProductListVM model = new ProductListVM()
            {
                Products = _productOperation.GetAll()
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
