using Resourse_Module;
using Resourse_Module.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IResourseAccess res = new ResourceAccess(typeof(MyResource));
            //res.ResourceType = typeof(Resource);
            //res.CurrentCulture = new System.Globalization.CultureInfo("de-GE");
            Console.WriteLine(res.Resources["name"]);
            Console.ReadKey();
            
        }
    }
}
