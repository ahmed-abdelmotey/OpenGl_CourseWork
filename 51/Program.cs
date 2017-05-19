using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _51
{
    static class Program
    {
        static void Main()
        {
            using (SimpleViewer s = new SimpleViewer("ArcBall"))
            {
                s.Run();
            }
        }
    }
}
