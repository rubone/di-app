using DependencyInjectionApp.Interfaces;
using DependencyInjectionApp.Models;
using DependencyInjectionApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInjectionApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly OperationService _operationService;
        
        private readonly IOperationTransient _operationTransient;

        private readonly IOperationScoped _operationScoped;

        private readonly IOperationSingleton _operationSingleton;

        private readonly IOperationSingletonInstance _operationSingletonInstance;


        public HomeController(ILogger<HomeController> logger,
            OperationService operationService,
            IOperationTransient operationTransient,
            IOperationScoped operationScoped,
            IOperationSingleton operationSingleton,
            IOperationSingletonInstance operationSingletonInstance)
        {
            _logger = logger;
            _operationService = operationService;
            _operationTransient = operationTransient;
            _operationScoped = operationScoped;
            _operationSingleton = operationSingleton;
            _operationSingletonInstance = operationSingletonInstance;
        }

        public IActionResult Index()
        {
            ViewBag.Transient = _operationTransient;
            ViewBag.Scoped = _operationScoped;
            ViewBag.Singleton = _operationSingleton;
            ViewBag.SingletonInstance = _operationSingletonInstance;

            ViewBag.Service = _operationService;

            return View();
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
