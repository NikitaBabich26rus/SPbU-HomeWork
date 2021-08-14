using System.Globalization;
using System.Net;
using System.Windows.Controls;

namespace HomeWork6
{
    public class PortValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var port = value as string;
            if (int.TryParse(port, out int portNumber) && portNumber <= IPEndPoint.MaxPort && portNumber >= IPEndPoint.MinPort)
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Incorrect port.");
        }
    }
}
