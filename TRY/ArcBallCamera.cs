using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace Project
{
    class ArcBallCamera : Camera
    {
        #region Properties
        public float Sensitivity { get; set; }
        public double Theta { get; set; }
        public double Phi { get; set; }
        public double R { get; set; }        
        #endregion
        #region Camera Position
        public void ModifyPosition()
        {
            Position = new Vector3((float)(R * Math.Sin(Phi) * Math.Cos(Theta)), (float)(R * Math.Cos(Phi)), (float)(R * Math.Sin(Phi) * Math.Sin(Theta)));
            ViewMatrix = Matrix4.LookAt(Position, Forward, Up);
            if (ProjectType == ProjectionType.Prespective)
            {
                this.ProjMatrix = Matrix4.CreatePerspectiveFieldOfView(Fovy, AspectRatio * Height * 1.0f / Height, Near, Far);
            }
            else if (ProjectType == ProjectionType.Parellel)
            {
                this.ProjMatrix = Matrix4.CreateOrthographic(AspectRatio * Height * 1.0f, Height, Near, Far); ;
            }
        }
        public void UpdatePosition(int dx, int dy)
        {
            Theta += dx / Sensitivity;
            Phi -= dy / Sensitivity;
            ModifyPosition();
        }
        public void UpdateZoom(int delta)
        {
            R -= delta;
            ModifyPosition();
        }
        #endregion
        public ArcBallCamera():base(new Vector3(15,15,15),Vector3.Zero,Vector3.UnitY,ProjectionType.Prespective,(float)(Math.PI/3),1.5f,1,50,400)
        {
            Theta = Math.Atan2(Position.Z, Position.X);
            Phi = Math.Atan2(Math.Sqrt(Position.X * Position.X + Position.Z * Position.Z), Position.X);
            R = Math.Sqrt(Position.X * Position.X + Position.Y * Position.Y + Position.Z * Position.Z);
            Sensitivity = 100;
        }
    }
}
