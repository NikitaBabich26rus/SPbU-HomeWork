using System.Net;

namespace HomeWork6
{
    /// <summary>
    /// Validation class.
    /// </summary>
    public static class InputValidation
    {
        /// <summary>
        /// Checking the ip for correctness.
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns>Correct or not.</returns>
        public static bool IpValidation(string ip) => IPAddress.TryParse(ip, out _);

        /// <summary>
        /// Checking the port for correctness.
        /// </summary>
        /// <param name="port">port</param>
        /// <returns>Correct or not.</returns>
        public static bool PortValidation(string port)
        {
            int portNumber;
            if (int.TryParse(port, out portNumber) && portNumber > IPEndPoint.MaxPort && portNumber < IPEndPoint.MinPort)
            {
                return true;
            }
            return false;
        }
    }
}
