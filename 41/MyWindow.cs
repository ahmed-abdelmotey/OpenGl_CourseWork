using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System.IO;
using System.Collections;
namespace _41
{
    struct Vertex
    {
        public Vector3 Position { get; set; }
        public Vector3 Color { get; set; }
        public static int SizeInBytes
        {
            get { return 2 * Vector3.SizeInBytes; }
        }
        public Vertex(Vector3 pos,Vector3 color):this()
        {
            Position = pos;
            Color = color;
        }
    }
    class MyWindow:GameWindow
    {
        Shader sh;
        float theta = 0;
        Matrix4 modelMat;
        List<int> indices = new List<int>();
        Vertex[] coreVertices =
        {
            new Vertex(new Vector3(-0.5f,0.5f,0.5f),new Vector3(1,0,0)),
            new Vertex(new Vector3(-0.5f,-0.5f,0.5f),new Vector3(0,1,0)),
            new Vertex(new Vector3(0.5f,-0.5f,0.5f),new Vector3(0,0,1)),
            new Vertex(new Vector3(0.5f,0.5f,0.5f),new Vector3(0,1,1)),

            new Vertex(new Vector3(0.5f,0.5f,-0.5f),new Vector3(1,0,1)),
            new Vertex(new Vector3(0.5f,-0.5f,-0.5f),new Vector3(1,1,0)),
            new Vertex(new Vector3(-0.5f,-0.5f,-0.5f),new Vector3(1,1,1)),
            new Vertex(new Vector3(-0.5f,0.5f,-0.5f),new Vector3(0,0,0))
        };
        List<Vertex> vertices = new List<Vertex>();
        void Cube()
        {
            Quad(new Vector3(1, 1, 1), 0, 0, 1, 2, 3);
            Quad(new Vector3(0, 1, 0), 1, 3, 2, 5, 4);
            Quad(new Vector3(0, 0, 1), 2, 4, 5, 6, 7);
            Quad(new Vector3(1, 0, 0), 3, 0, 7, 6, 1);
            Quad(new Vector3(1, 1, 0), 4, 7, 0, 3, 4);
            Quad(new Vector3(0, 1, 1), 5, 1, 6, 5, 2);
        }
        void Quad(Vector3 color,int faceno, params int[] index)
        {
            foreach (int i in index)
            {
                vertices.Add(new Vertex(coreVertices[i].Position, color));
            }
            int indent = faceno * 4;
            indices.AddRange(new int[] { indent, indent + 1, indent + 3, indent + 3, indent + 1, indent + 2 });
        }
        public MyWindow():base(400,300)
        {
            this.Title = "First OpenTK app";
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(0, 0, 0, 1);

            sh = Shader.CreateShader("Vs.glsl", "FS.glsl");
            sh.UseShader();
  
            Cube();

            int bufferid = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, bufferid);
            GL.BufferData<Vertex>(BufferTarget.ArrayBuffer, vertices.Count * Vertex.SizeInBytes,
                vertices.ToArray(), BufferUsageHint.StaticDraw);

            int indicesBuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, indicesBuffer);
            GL.BufferData<int>(BufferTarget.ElementArrayBuffer, 4 * 36, indices.ToArray(), BufferUsageHint.StaticDraw);


            int vertex_position_loc = sh.GetAttribLocation("vertex_position");
            GL.VertexAttribPointer(vertex_position_loc, 3, VertexAttribPointerType.Float, false, Vertex.SizeInBytes, 0);
            GL.EnableVertexAttribArray(vertex_position_loc);

            int vertex_color_loc = sh.GetAttribLocation("vertex_color");
            GL.VertexAttribPointer(vertex_color_loc, 3, VertexAttribPointerType.Float, false, Vertex.SizeInBytes, Vector3.SizeInBytes);
            GL.EnableVertexAttribArray(vertex_color_loc);

            GL.Enable(EnableCap.DepthTest);
            modelMat = Matrix4.Identity; // moved from initShader
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit| ClearBufferMask.DepthBufferBit);
            //GL.PointSize(10);
            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.LineWidth(4);
            //GL.DrawArrays(PrimitiveType.Triangles, 0, vertices.Count);
            GL.DrawElements(PrimitiveType.Triangles, indices.Count, DrawElementsType.UnsignedInt, IntPtr.Zero);
            SwapBuffers();
        }
     
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            
            base.OnUpdateFrame(e);
            theta += 0.01f;
            modelMat = Matrix4.CreateRotationX(theta) * Matrix4.CreateRotationY(theta * 2) * Matrix4.CreateRotationZ(theta / 2);
            int modelMatLocation = sh.GetUniformLocation("modelMat");
            GL.UniformMatrix4(modelMatLocation, false, ref modelMat);
            

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
    }
}
