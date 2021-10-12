using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atributes
{
    /// <summary>
    /// Attribute to run methods after tests class
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class AfterClass : Attribute
    {

    }
}
