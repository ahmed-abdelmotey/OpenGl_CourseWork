using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using OpenTK;
using OpenTK.Input;
using System.Drawing;
using System.Drawing.Imaging;

namespace _51
{
    class SimpleViewer : GameWindow
    {
        #region Form Variables
        bool mousePressed = false;
        bool isUsingVSphong = true;
        #endregion
        #region Declare Objectes
        Shader unlitShader;
        Shader VSphong;
        Shader FSphong;
        Mesh Quad;
        Mesh Cube;
        Mesh Ball;
        Mesh PrismBall;
        Mesh Grid;
        ArcBallCamera cam;
        #endregion
        #region Mouse Events
        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            mousePressed = true;
        }
        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);
            mousePressed = false;
        }
        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            if (mousePressed)
            {
                cam.UpdatePosition(e.XDelta, e.YDelta);
            }
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            base.OnMouseWheel(e);
            cam.UpdateZoom(e.Delta);
        }
        #endregion
        public SimpleViewer(string title): base(800, 600)
        {
            this.Title = title;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // adjust settings
            GL.ClearColor(0.3f, 0.3f, 0.3f, 1);
            GL.Enable(EnableCap.DepthTest);

            // initialize shaders
            unlitShader = Shader.CreateShader("Shaders//UnlitColorVS.glsl", "Shaders//UnlitColorFS.glsl");
            VSphong = Shader.CreateShader("Shaders//phongVS.glsl", "Shaders//phongFS.glsl");
            FSphong = Shader.CreateShader("Shaders//FphongVS.glsl", "Shaders//FphongFS.glsl");

            // initialze meshes
            PrismBall = Mesh.CreatePrismSphere(VSphong, 3);
            Ball = Mesh.CreateSphere(VSphong, 1, 20, 20);
            Cube = Mesh.CreateCube(VSphong, 2, 2, 2, new Vector4(0.7f, 0.7f, 0.7f, 1));
            Quad = Mesh.CreateQuad(VSphong, 1, 1, 1);
            Grid = Mesh.CreateGrid(unlitShader, 5, 1, new Vector4(0.7f, 0.7f, 0.7f, 1));

            // initialize camera
            cam = new ArcBallCamera();
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            Grid.Render(cam);
            //Quad.Render(cam);
            //Cube.Render(cam);
            Ball.Render(cam);
            //PrismBall.Render(cam);
            SwapBuffers();
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (e.KeyChar == ' ')
            {
                if (isUsingVSphong)
                {
                    PrismBall.Shader = FSphong;
                    Ball.Shader = FSphong;
                    Cube.Shader = FSphong;
                    Quad.Shader = FSphong;
                    Grid.Shader = FSphong;
                    isUsingVSphong = false;
                }
                else
                {
                    PrismBall.Shader = VSphong;
                    Ball.Shader = VSphong;
                    Cube.Shader = VSphong;
                    Quad.Shader = VSphong;
                    Grid.Shader = VSphong;
                    isUsingVSphong = true;
                }

            }
        }
    }
}
