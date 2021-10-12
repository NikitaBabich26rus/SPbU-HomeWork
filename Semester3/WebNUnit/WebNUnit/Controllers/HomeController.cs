using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyNUnitRunner;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebNUnit.Models;
using WebNUnit.Repository;

namespace WebNUnit.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
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
        /// Load assembly.
        /// </summary>
        /// <param name="file">Path to assembly.</param>
        /// <returns>Current loaded assemblies.</returns>
        [HttpPost("loadTheAssembly")]
        public async Task<List<LoadAssemblyViewModel>> LoadTheAssembly(IFormFile file)
        {
            if (file != null && !FileIsContain(file.FileName))
            {
                using var stream = new FileStream($"{Path.Combine(pathToFolderWithTests, file.FileName)}", FileMode.Create);
                await file.CopyToAsync(stream);
                var assembly = await homeRepository.LoadAssemblies.AddAsync(new LoadAssemblyViewModel { Name = file.FileName });
                await homeRepository.SaveChangesAsync();
            }
            return homeRepository.LoadAssemblies.ToList();
        }

        /// <summary>
        /// Checks whether the assembly is loaded.
        /// </summary>
        /// <param name="fileName">File name.</param>
        /// <returns>Is loaded or not.</returns>
        private bool FileIsContain(string fileName)
            => homeRepository.LoadAssemblies
                .ToList()
                .Any(x => x.Name == fileName);

        /// <summary>
        ///  Get loaded assemblies.
        /// </summary>
        /// <returns>Current loaded assemblies.</returns>
        [HttpGet("getLoadAssembly")]
        public List<LoadAssemblyViewModel> GetLoadAssemblies()
            => homeRepository.LoadAssemblies.ToList();
        
        /// <summary>
        /// Delete loaded assemblies.
        /// </summary>
        [HttpDelete("deleteLoadedAssemblies")]
        public async Task DeleteLoadAssemblies()
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
            await homeRepository.SaveChangesAsync();
        }
        
        /// <summary>
        /// Run testing.
        /// </summary>
        /// <returns>Results of testing.</returns>
        [HttpGet("runLoadedTests")]
        public async Task<List<AssemblyViewModel>> RunTests()
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
                testsList.Add(assembly);
            }
            await homeRepository.SaveChangesAsync();
            return testsList;
        }

        /// <summary>
        ///  Get history of testing.
        /// </summary>
        /// <returns>History.</returns>
        [HttpGet("getHistory")]
        public IEnumerable<AssemblyViewModel> History()
        {
            var assemblies = homeRepository.AssembliesHistory
                .Include(x => x.Tests)
                .ToList()
                .Reverse<AssemblyViewModel>();
            return assemblies;
        }
    }
}
