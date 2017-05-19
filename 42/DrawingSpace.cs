using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;


namespace _42
{
    class DrawingSpace :GameWindow
    {
        Shader unlitShader;
        List<List<Vector2>> positions;
        List<Vector2> temp = null;
        bool isPressed = false;
        public DrawingSpace(string title):base(800,600)
        {
            this.Title = title;
            positions = new List<List<Vector2>>();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(1, 1, 1, 1);
            unlitShader = Shader.CreateShader("VS.glsl", "FS.glsl");
            unlitShader.UseShader();
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.LineWidth(4);

            int bufferid = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, bufferid);

            foreach (List<Vector2> shape in positions)
            {
                GL.BufferData<Vector2>(BufferTarget.ArrayBuffer, shape.Count * Vector2.SizeInBytes, shape.ToArray(), BufferUsageHint.StaticDraw);

                int vertex_position_loc = unlitShader.GetAttribLocation("vertex_position");
                GL.VertexAttribPointer(vertex_position_loc, 2, VertexAttribPointerType.Float, false, Vector2.SizeInBytes, 0);
                GL.EnableVertexAttribArray(vertex_position_loc);

                GL.DrawArrays(PrimitiveType.LineStrip, 0, shape.Count);
            }

            GL.Enable(EnableCap.DepthTest);
            SwapBuffers();
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
        }
        protected override void OnMouseDown(OpenTK.Input.MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            isPressed = true;
            temp = new List<Vector2>();
            positions.Add(temp);

            float halfW = Width / 2.0f; float halfH = Height / 2.0f;
            temp.Add(new Vector2((e.X - halfW) / halfW, (halfH - e.Y) / halfH));
        }
        protected override void OnMouseUp(OpenTK.Input.MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            isPressed = false;
            temp = null;
        }
        protected override void OnMouseMove(OpenTK.Input.MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            if (isPressed)
            {
                this.Title = e.X.ToString() + " - " + e.Y.ToString();
                float halfW = Width / 2.0f; float halfH = Height / 2.0f;
                temp.Add(new Vector2((e.X - halfW) / halfW, (halfH - e.Y) / halfH));
            }
        }
        protected override void OnKeyDown(OpenTK.Input.KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.Control && e.Key == Key.Z && positions.Count != 0)
            {
                positions.Remove(positions.Last());
            }
        }
    }
}
