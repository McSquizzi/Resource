using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Resourse_Module
{
    public interface IResourseAccess
    {
        IDictionary<string, string> Resources { get; }
        Type ResourceType { get; set; }
        CultureInfo CurrentCulture { get; set; }


    }
}
