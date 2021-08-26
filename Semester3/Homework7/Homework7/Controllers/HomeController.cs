using Homework7.Models;
using Homework7.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyNUnitRunner;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Homework7.Controllers
{
    /// <summary>
    /// Web controller class.
    /// </summary>
    public class HomeController : Controller
    {
        private HomeRepository homeRepository;
        private readonly string pathToFolderWithTests = Directory.GetCurrentDirectory() + "\\Tests";
        private MyNUnit myNUnit;

        /// <summary>
        /// Controller constructor.
        /// </summary>
        public HomeController()
        {
            homeRepository = new();
            myNUnit = new();
        }

        /// <summary>
        /// View start page.
        /// </summary>
        /// <returns>View.</returns>
        public IActionResult Index()
            => View();

        /// <summary>
        ///  View for load assembly.
        /// </summary>
        /// <returns>Current loaded assemblies.</returns>
        public IActionResult LoadAssemblyPage()
            => View("LoadAssemblyPage", homeRepository.LoadAssemblies.ToList());

        /// <summary>
        /// Load assembly.
        /// </summary>
        /// <param name="file">Path to assembly.</param>
        /// <returns>Current loaded assemblies.</returns>
        public IActionResult LoadTheAssembly(IFormFile file)
        {
            if (file != null)
            {
                using var stream = new FileStream($"{Path.Combine(pathToFolderWithTests, file.FileName)}", FileMode.Create);
                file.CopyTo(stream);
                var assembly = homeRepository.LoadAssemblies.Add(new LoadAssemblyViewModel { Name = file.FileName });
                homeRepository.SaveChanges();
            }
            return View("LoadAssemblyPage", homeRepository.LoadAssemblies.ToList());
        }

        /// <summary>
        /// Delete loaded assemblies.
        /// </summary>
        /// <returns>View.</returns>
        public IActionResult DeleteLoadAssemblies()
        {
            if (Directory.EnumerateFileSystemEntries(pathToFolderWithTests).Any())
            {
                var directory = new DirectoryInfo(pathToFolderWithTests);
                foreach (var file in directory.GetFiles())
                {
                    file.Delete();
                }
            }
            homeRepository.LoadAssemblies.RemoveRange(homeRepository.LoadAssemblies);
            homeRepository.SaveChanges();
            return View("LoadAssemblyPage");
        }

        /// <summary>
        ///  View testing page.
        /// </summary>
        /// <returns>View.</returns>
        public IActionResult Testing()
            => View("Testing");

        /// <summary>
        /// Run testing.
        /// </summary>
        /// <returns>Results of testing.</returns>
        public IActionResult RunTests()
        {
            var assembliesTests = myNUnit.MyNUnitRun(pathToFolderWithTests);
            var testsList = new List<AssemblyViewModel>();
            while (!assembliesTests.IsEmpty)
            {
                var assembly = new AssemblyViewModel();
                assembly.Tests = new List<TestViewModel>();
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
                homeRepository.AssembliesHistory.Add(new AssemblyViewModel
                {
                    Name = assembly.Name,
                    Tests = assembly.Tests
                });
                homeRepository.SaveChanges();
                testsList.Add(assembly);
            }
            return View("Testing", testsList);
        }

        /// <summary>
        ///  View history of testing.
        /// </summary>
        /// <returns>History.</returns>
        public IActionResult History()
        {
            var assemblies = homeRepository.AssembliesHistory
                .Include(x => x.Tests)
                .ToList()
                .Reverse<AssemblyViewModel>();
            return View("History", assemblies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}