using Homework7.Models;
using Homework7.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyNUnitRunner;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace Homework7.Controllers
{
    public class HomeController : Controller
    {
        private HomeRepository homeRepository;
        private readonly ILogger<HomeController> logger;
        private readonly string pathToFolderWithTests = Directory.GetCurrentDirectory() + "\\Tests";
        private MyNUnit myNUnit = new();

        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
            this.homeRepository = new HomeRepository();
        }

        public IActionResult Index()
            => View();

        public IActionResult LoadAssemblyPage()
            => View("LoadAssemblyPage");

        public async Task<IActionResult> LoadTheAssembly(IFormFile file)
        {
            if (file != null)
            {
                using var stream = new FileStream($"{Path.Combine(pathToFolderWithTests, file.FileName)}", FileMode.Create);
                await file.CopyToAsync(stream);
            }
            return View("LoadAssemblyPage");
        }

        public IActionResult Testing()
            => View("Testing");

        public IActionResult RunTests()
        {
            var assembliesTests = myNUnit.MyNUnitRun(pathToFolderWithTests);
            var testsList = new List<AssemblyLoadViewModel>();
            while (!assembliesTests.IsEmpty)
            {
                var assembly = new AssemblyLoadViewModel();
                assembliesTests.TryDequeue(out var info);
                assembly.Name = info.Name;
                var infoArray = info.Tests.ToArray();
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
                    assembly.Tests.Add(test);
                }
                testsList.Add(assembly);
                //homeRepository.Assemblies.Add(assembly);
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