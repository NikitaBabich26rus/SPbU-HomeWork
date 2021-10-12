namespace Homework7.Models
{
    /// <summary>
    /// ViewModel for error.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Error request id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Show error request id.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
