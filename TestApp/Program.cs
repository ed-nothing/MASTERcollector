using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MASTERcollector.Framework.GetInstance().Initialize();
            MASTERcollector.Framework.GetInstance().Configuration["TEST"] = "TEST";
        }
    }
}
