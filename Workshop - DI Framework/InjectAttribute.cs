using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workshop___DI_Framework
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple =false )]
    public class InjectAttribute : Attribute
    {
    }
}
