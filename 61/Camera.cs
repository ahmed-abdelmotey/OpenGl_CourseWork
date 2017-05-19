using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace _61
{
    enum ProjectionType
    {
        Prespective,
        Parellel
    }
    abstract class Camera
    {
        public Vector3 Position { get; set; }
        public Vector3 Forward { get; set; }
        public Vector3 Up { get; set; }
        public ProjectionType ProjectType { get; set; }
        public float Fovy { get; set; }
        public float AspectRatio { get; set; }
        public int Near { get; set; }
        public int Far { get; set; }
        public float Height { get; set; }
        public Matrix4 ViewMatrix { get; set; }
        public Matrix4 ProjMatrix { get; set; }
        public Camera(Vector3 position, Vector3 forward, Vector3 up,ProjectionType projectionType,float fovy,float aspectRatio,int near,int far,float height)
        {
            this.Position = position; this.Forward = forward; this.Up = up; this.ProjectType = projectionType;
            this.Fovy = fovy; this.AspectRatio = aspectRatio; this.Near = near; this.Height = height; this.Far = far;

            this.ViewMatrix = Matrix4.LookAt(Position, Forward, Up);
            if (ProjectType == ProjectionType.Prespective)
            {
                this.ProjMatrix = Matrix4.CreatePerspectiveFieldOfView(Fovy, AspectRatio * Height * 1.0f / Height, Near, Far);
            }
            else if (ProjectType == ProjectionType.Parellel)
            {
                this.ProjMatrix = Matrix4.CreateOrthographic(AspectRatio * Height * 1.0f, Height, Near, Far); ;             
            }
        }
    }
}
