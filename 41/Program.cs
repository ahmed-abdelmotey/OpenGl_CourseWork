using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _41
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MyWindow window = new MyWindow())
            {
                window.Run();
            }
        }
    }
}
