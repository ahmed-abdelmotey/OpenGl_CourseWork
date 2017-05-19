using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _43
{
    class Program
    {
        static void Main(string[] args)
        {
            using (sinWaveMonitor sin = new sinWaveMonitor("sinWaveMonitor"))
            {
                sin.Run();
            }
        }
    }
}
