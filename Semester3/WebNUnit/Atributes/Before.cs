using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributes
{
    /// <summary>
    /// Attribute to run methods before tests
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class Before : Attribute
    {
    }
}
