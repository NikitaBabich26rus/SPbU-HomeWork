using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace HomeWork6
{
    public static class InputValidation
    {
        public static bool IpValidation(string ip) => IPAddress.TryParse(ip, out _);

        public static bool PortValidation(string port)
        {
            if (int.TryParse()
        }
    }
}
