using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;


namespace _43
{
    class sinWaveMonitor :GameWindow
    {
        float dx = 0;        
        List<float> positions = new List<float>();
        Shader sh;
        public sinWaveMonitor(string title) : base(800,600)
        {
            this.Title = title;
        }
        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);

            sh = Shader.CreateShader("Vs.glsl", "FS.glsl");
            sh.UseShader();

            for (float i = -0.9f; i < 0.9f; i += 1.8f / Width)
            {
                positions.Add(i);
            }

            int bufferid = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, bufferid);
            GL.BufferData<float>(BufferTarget.ArrayBuffer, positions.Count * sizeof(float),positions.ToArray(), BufferUsageHint.StaticDraw);

            int vertex_position_loc = sh.GetAttribLocation("vertex_x");
            GL.VertexAttribPointer(vertex_position_loc, 1, VertexAttribPointerType.Float, false, sizeof(float), 0);
            GL.EnableVertexAttribArray(vertex_position_loc);
            
            GL.Enable(EnableCap.DepthTest);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LineWidth(4);
            GL.DrawArrays(PrimitiveType.LineStrip, 0, positions.Count);
            SwapBuffers();
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            dx += 0.1f;
            int dx_loc = sh.GetUniformLocation("dx");
            GL.Uniform1(dx_loc, dx);
        }
    }
}
