using System.ComponentModel.DataAnnotations;

namespace Homework7.Models
{
    /// <summary>
    /// View model for loaded assembly.
    /// </summary>
    public class LoadAssemblyViewModel
    {
        /// <summary>
        /// Loaded assembly id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Loaded assembly name.
        /// </summary>
        public string Name { get; set; }
    }
}
