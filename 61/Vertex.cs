using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace _61
{
    struct Vertex
    {
        Vector3 position;
        Vector3 normal;
        Vector2 uv;
        // Vector3 color;
        public Vertex(Vector3 position, Vector3 normal, Vector2 uv)
        {
            this.position = position;
            this.normal = normal;
            this.uv = uv;
        }
        public Vertex(Vector3 position, Vector3 normal) : this(position, normal, Vector2.Zero) { }
        public Vertex(Vector3 position) : this(position, Vector3.Zero, Vector2.Zero) { }
        public static int SizeInBytes
        {
            get { return Vector3.SizeInBytes * 2 + Vector2.SizeInBytes; }
        }
    }
}
