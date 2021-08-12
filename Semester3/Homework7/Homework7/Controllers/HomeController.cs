using Homework7.Models;
using Homework7.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyNUnitRunner;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Homework7.Controllers
{
    public class HomeController : Controller
    {
        private HomeRepository _homeRepository;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _homeRepository = new HomeRepository();
        }

        public IActionResult Index()
            => View();

        public IActionResult LoadAssemblyPage()
            => View();

        [HttpPost]
        public IActionResult LoadTheAssembly(IFormFile file)
        {
            return View();
        }

        public IActionResult Testing()
        {
            var tests = new MyNUnit("../PassedTests");
            tests.ClassQueue.TryDequeue(out var info);
            var infoArray = info.ToArray();
            var testsList = new List<TestViewModel>();
            foreach (var item in infoArray)
            {
                var test = new TestViewModel();
                test.Result = item.Result;
                test.Name = item.Name;
                test.StartTime = DateTime.Now;
                if (item.Result == "Passed")
                {
                    test.Time = item.Time;
                }
                else
                {
                    test.IgnoreReason = item.IgnoreReason;
                }
                testsList.Add(test);
            }
            return View("Testing", testsList);
        }
            

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}