using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework7.Models
{
    public class AssemblyLoadViewModel
    {
        public string Name { get; set; }

        public string Id { get; set; }

        public List<TestViewModel> Tests { get; set; } = new();
    }
}
