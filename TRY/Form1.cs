using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;

namespace Project
{
    public partial class Form1 : Form
    {
        #region Form Variables
        ArcBallCamera cam;

        Shader unlitShader;
        Shader VSphong;
        Shader FSphong;
        Shader SelectedShader;

        Mesh Grid;

        List<Mesh> Objects = new List<Mesh>();
        Mesh CurrentlySelected;

        bool mousePressed = false;
        bool isWireframe = false;
        #endregion
        #region Form
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            // assign glcontroler events
            glControl1.MouseDown += glControl1_MouseDown;
            glControl1.MouseMove += glControl1_MouseMove;
            glControl1.MouseUp += glControl1_MouseUp;
            glControl1.MouseWheel += glControl1_MouseWheel;

            // assign sliders event
            trk_posX.ValueChanged += PositionValueChanged;
            trk_posY.ValueChanged += PositionValueChanged;
            trk_posZ.ValueChanged += PositionValueChanged;

            trk_rotX.ValueChanged += RotationValueChanged;
            trk_rotY.ValueChanged += RotationValueChanged;
            trk_rotZ.ValueChanged += RotationValueChanged;

            trk_sclX.ValueChanged += ScaleValueChanged;
            trk_sclY.ValueChanged += ScaleValueChanged;
            trk_sclZ.ValueChanged += ScaleValueChanged;

            trk_clrR.ValueChanged += ColorValueChanged;
            trk_clrG.ValueChanged += ColorValueChanged;
            trk_clrB.ValueChanged += ColorValueChanged;
        }
        #endregion
        #region Menu Strip
        private void cubeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Objects.Add(Mesh.CreateCube(VSphong, 2, 2, 2, new Vector4(0.2f, 0.4f, 0.7f, 1)));
            lst_objects.Items.Add(string.Format("{0}- Cube", Objects.Count));
            CurrentlySelected = Objects.Last();
            getValuesOfObject(CurrentlySelected);
        }
        private void ballToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Objects.Add(Mesh.CreateSphere(VSphong, 2,20,20));
            lst_objects.Items.Add(string.Format("{0}- Sphere", Objects.Count));
            CurrentlySelected = Objects.Last();
            getValuesOfObject(CurrentlySelected);
        }
        private void prismBallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Objects.Add(Mesh.CreatePrismSphere(VSphong, 4));
            lst_objects.Items.Add(string.Format("{0}- Prism Sphere", Objects.Count));
            CurrentlySelected = Objects.Last();
            getValuesOfObject(CurrentlySelected);
        }
        private void wireframeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (wireframeToolStripMenuItem.Checked)
            {
                isWireframe = true;
            }
            else
            {
                isWireframe = false;
            }
        }
        private void smoothVSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedShader = VSphong;
        }
        private void smoothFSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedShader = FSphong;
        }
        private void uploadObjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                Mesh m = Mesh.LoadFromFile(openFileDialog1.FileName, SelectedShader);
                if (m != null)
                {
                    Objects.Add(m);
                    lst_objects.Items.Add(new ListViewItem(string.Format("{0}- Object", Objects.Count)));
                }
            }
        }
        #endregion
        #region ListView
        // select item from list
        private void lst_objects_ItemActivate(object sender, EventArgs e)
        {
            //CurrentlySelected = Objects[int.Parse((lst_objects.SelectedItems)[0].Text.Split('-').First()) - 1];
            CurrentlySelected = Objects[lst_objects.SelectedIndices[0]-1];
            getValuesOfObject(CurrentlySelected);
        }
        #endregion
        #region Controlers
        void getValuesOfObject(Mesh obj)
        {
            if (CurrentlySelected != null)
            {
                // get positions
                trk_posX.Value = (int)(obj.Position.X * 100);
                trk_posY.Value = (int)(obj.Position.Y * 100);
                trk_posZ.Value = (int)(obj.Position.Z * 100);

                // get scale
                trk_sclX.Value = (int)(obj.Scale.X);
                trk_sclY.Value = (int)(obj.Scale.Y);
                trk_sclZ.Value = (int)(obj.Scale.Z);

                // get rotation
                trk_rotX.Value = (int)(obj.Rotation.X * (180.0 / Math.PI));
                trk_rotY.Value = (int)(obj.Rotation.Y * (180.0 / Math.PI));
                trk_rotZ.Value = (int)(obj.Rotation.Z * (180.0 / Math.PI));

                // get Color
                trk_clrR.Value = (int)(obj.MatColor.X * 100);
                trk_clrG.Value = (int)(obj.MatColor.Y * 100);
                trk_clrB.Value = (int)(obj.MatColor.Z * 100);
            }
        }
        void PositionValueChanged(object sender, EventArgs e)
        {
            CurrentlySelected.Position = new Vector3(trk_posX.Value / 100.0f, trk_posY.Value / 100.0f, trk_posZ.Value / 100.0f);
            glControl1.Invalidate();
        }
        void ScaleValueChanged(object sender, EventArgs e)
        {
            CurrentlySelected.Scale = new Vector3(trk_sclX.Value + 1, trk_sclY.Value + 1, trk_sclZ.Value + 1);
            glControl1.Invalidate();
        }
        void RotationValueChanged(object sender, EventArgs e)
        {
            CurrentlySelected.Rotation = new Vector3((float)(Math.PI * trk_rotX.Value / 180.0), (float)(Math.PI * trk_rotY.Value / 180.0), (float)(Math.PI * trk_rotZ.Value / 180.0));
            glControl1.Invalidate();
        }
        void ColorValueChanged(object sender, EventArgs e)
        {
            CurrentlySelected.MatColor = new Vector4(trk_clrR.Value / 100.0f, trk_clrG.Value / 100.0f, trk_clrB.Value / 100.0f, 1);
            glControl1.Invalidate();
        }
        private void btn_remove_Click(object sender, EventArgs e)
        {
            Objects.Remove(CurrentlySelected);
            lst_objects.Items.Remove(lst_objects.SelectedItems[0]);
        }
        #endregion
        #region GLControler
        private void glControl1_Load(object sender, EventArgs e)
        {
            // adjust settings
            GL.Enable(EnableCap.DepthTest);

            // initialize shaders
            unlitShader = Shader.CreateShader("Shaders//UnlitColorVS.glsl", "Shaders//UnlitColorFS.glsl");
            VSphong = Shader.CreateShader("Shaders//phongVS.glsl", "Shaders//phongFS.glsl");
            FSphong = Shader.CreateShader("Shaders//FphongVS.glsl", "Shaders//FphongFS.glsl");

            SelectedShader = VSphong;

            // Create Grid
            Grid = Mesh.CreateGrid(unlitShader, 5, 1, new Vector4(0.7f, 0.7f, 0.7f, 1));

            // initialize camera
            cam = new ArcBallCamera();
            cam.setViewPortDims(glControl1.Width, glControl1.Height);
            
        }
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            // set options
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.ClearColor(0.3f, 0.3f, 0.3f, 1);
            glControl1.Invalidate();

            // set camera viewport size in case of resizing
            cam.setViewPortDims(glControl1.Width, glControl1.Height);

            Grid.Render(cam,false);
            foreach (Mesh m in Objects)
            {
                m.Shader = SelectedShader;

                m.Render(cam,isWireframe);
            }
            // swap buffers
            glControl1.SwapBuffers();           
        }
        #endregion
        #region Mouse Events
        int tempX;
        int tempY;
        private void glControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mousePressed = true;
            tempX = e.Location.X;
            tempY = e.Location.Y;
        }
        private void glControl1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            mousePressed = false;
        }
        private void glControl1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (mousePressed)
            {
                cam.UpdatePosition(e.Location.X - tempX, e.Location.Y - tempY);
                tempX = e.Location.X;
                tempY = e.Location.Y;
                glControl1.Invalidate();
            }
        }
        private void glControl1_MouseWheel(object sender, MouseEventArgs e)
        {
            cam.UpdateZoom(e.Delta/100);
            glControl1.Invalidate();
        }
        #endregion

        private void parallelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cam.ProjectType = ProjectionType.Parellel;
            // zooming is to change width and height ? check if you have time
        }

        private void prespectiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cam.ProjectType = ProjectionType.Prespective;
        }
    }
}
