using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _42
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DrawingSpace dwg = new DrawingSpace("Drawing Space"))
            {
                dwg.Run();
            }
        }
    }
}
