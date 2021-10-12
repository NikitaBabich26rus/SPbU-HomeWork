using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebNUnit.Models
{
    /// <summary>
    /// View model for assembly.
    /// </summary>
    public class AssemblyViewModel
    {
        /// <summary>
        /// Assembly id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Assembly name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Assembly tests.
        /// </summary>
        public List<TestViewModel> Tests { get; set; } = new();
    }
}
