using System.Globalization;
using System.Net;
using System.Windows.Controls;

namespace HomeWork6
{
    public class IpValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var ip = value as string;
            if (IPAddress.TryParse(ip, out _))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Incorrect ip address.");
        }
    }
}
