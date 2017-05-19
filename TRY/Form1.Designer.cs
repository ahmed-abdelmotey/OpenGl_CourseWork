namespace Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("List");
            this.glControl1 = new OpenTK.GLControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_remove = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.trk_clrR = new System.Windows.Forms.TrackBar();
            this.trk_clrB = new System.Windows.Forms.TrackBar();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.trk_clrG = new System.Windows.Forms.TrackBar();
            this.grp_position = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.trk_posX = new System.Windows.Forms.TrackBar();
            this.trk_posZ = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trk_posY = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.trk_rotX = new System.Windows.Forms.TrackBar();
            this.trk_rotZ = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trk_rotY = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.trk_sclX = new System.Windows.Forms.TrackBar();
            this.trk_sclZ = new System.Windows.Forms.TrackBar();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.trk_sclY = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lst_objects = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addObjectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cubeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ballToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prismBallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadObjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visibilityModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wireframeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothVSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smoothFSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prespectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parallelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_clrR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_clrB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_clrG)).BeginInit();
            this.grp_position.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_posX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_posZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_posY)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_rotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_rotZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_rotY)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_sclX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_sclZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_sclY)).BeginInit();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Silver;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.glControl1.Location = new System.Drawing.Point(0, 24);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(933, 680);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_remove);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.grp_position);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(719, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(214, 680);
            this.panel1.TabIndex = 12;
            // 
            // btn_remove
            // 
            this.btn_remove.Location = new System.Drawing.Point(65, 645);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(90, 23);
            this.btn_remove.TabIndex = 11;
            this.btn_remove.Text = "Remove Object";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.btn_remove_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.trk_clrR);
            this.groupBox3.Controls.Add(this.trk_clrB);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.trk_clrG);
            this.groupBox3.Location = new System.Drawing.Point(10, 481);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(195, 154);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Color";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "B";
            // 
            // trk_clrR
            // 
            this.trk_clrR.Location = new System.Drawing.Point(32, 19);
            this.trk_clrR.Maximum = 100;
            this.trk_clrR.Name = "trk_clrR";
            this.trk_clrR.Size = new System.Drawing.Size(135, 45);
            this.trk_clrR.TabIndex = 1;
            this.trk_clrR.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trk_clrB
            // 
            this.trk_clrB.Location = new System.Drawing.Point(32, 105);
            this.trk_clrB.Maximum = 100;
            this.trk_clrB.Name = "trk_clrB";
            this.trk_clrB.Size = new System.Drawing.Size(135, 45);
            this.trk_clrB.TabIndex = 6;
            this.trk_clrB.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "R";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(15, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "G";
            // 
            // trk_clrG
            // 
            this.trk_clrG.Location = new System.Drawing.Point(32, 63);
            this.trk_clrG.Maximum = 100;
            this.trk_clrG.Name = "trk_clrG";
            this.trk_clrG.Size = new System.Drawing.Size(135, 45);
            this.trk_clrG.TabIndex = 4;
            this.trk_clrG.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // grp_position
            // 
            this.grp_position.Controls.Add(this.label3);
            this.grp_position.Controls.Add(this.trk_posX);
            this.grp_position.Controls.Add(this.trk_posZ);
            this.grp_position.Controls.Add(this.label1);
            this.grp_position.Controls.Add(this.label2);
            this.grp_position.Controls.Add(this.trk_posY);
            this.grp_position.Location = new System.Drawing.Point(10, 1);
            this.grp_position.Name = "grp_position";
            this.grp_position.Size = new System.Drawing.Size(195, 154);
            this.grp_position.TabIndex = 3;
            this.grp_position.TabStop = false;
            this.grp_position.Text = "Position";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Z";
            // 
            // trk_posX
            // 
            this.trk_posX.Location = new System.Drawing.Point(32, 17);
            this.trk_posX.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.trk_posX.Maximum = 500;
            this.trk_posX.Minimum = -500;
            this.trk_posX.Name = "trk_posX";
            this.trk_posX.Size = new System.Drawing.Size(135, 45);
            this.trk_posX.TabIndex = 1;
            this.trk_posX.TickFrequency = 0;
            this.trk_posX.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trk_posZ
            // 
            this.trk_posZ.Location = new System.Drawing.Point(32, 102);
            this.trk_posZ.Maximum = 500;
            this.trk_posZ.Minimum = -500;
            this.trk_posZ.Name = "trk_posZ";
            this.trk_posZ.Size = new System.Drawing.Size(135, 45);
            this.trk_posZ.TabIndex = 6;
            this.trk_posZ.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Y";
            // 
            // trk_posY
            // 
            this.trk_posY.Location = new System.Drawing.Point(32, 60);
            this.trk_posY.Maximum = 500;
            this.trk_posY.Minimum = -500;
            this.trk_posY.Name = "trk_posY";
            this.trk_posY.Size = new System.Drawing.Size(135, 45);
            this.trk_posY.TabIndex = 4;
            this.trk_posY.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.trk_rotX);
            this.groupBox1.Controls.Add(this.trk_rotZ);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.trk_rotY);
            this.groupBox1.Location = new System.Drawing.Point(10, 161);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(195, 154);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rotation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Z";
            // 
            // trk_rotX
            // 
            this.trk_rotX.Location = new System.Drawing.Point(32, 19);
            this.trk_rotX.Maximum = 180;
            this.trk_rotX.Minimum = -179;
            this.trk_rotX.Name = "trk_rotX";
            this.trk_rotX.Size = new System.Drawing.Size(135, 45);
            this.trk_rotX.TabIndex = 1;
            this.trk_rotX.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trk_rotZ
            // 
            this.trk_rotZ.Location = new System.Drawing.Point(32, 105);
            this.trk_rotZ.Maximum = 180;
            this.trk_rotZ.Minimum = -179;
            this.trk_rotZ.Name = "trk_rotZ";
            this.trk_rotZ.Size = new System.Drawing.Size(135, 45);
            this.trk_rotZ.TabIndex = 6;
            this.trk_rotZ.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "X";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Y";
            // 
            // trk_rotY
            // 
            this.trk_rotY.Location = new System.Drawing.Point(32, 63);
            this.trk_rotY.Maximum = 180;
            this.trk_rotY.Minimum = -179;
            this.trk_rotY.Name = "trk_rotY";
            this.trk_rotY.Size = new System.Drawing.Size(135, 45);
            this.trk_rotY.TabIndex = 4;
            this.trk_rotY.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.trk_sclX);
            this.groupBox2.Controls.Add(this.trk_sclZ);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.trk_sclY);
            this.groupBox2.Location = new System.Drawing.Point(10, 321);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(195, 154);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scale";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Z";
            // 
            // trk_sclX
            // 
            this.trk_sclX.Location = new System.Drawing.Point(32, 19);
            this.trk_sclX.Maximum = 5;
            this.trk_sclX.Name = "trk_sclX";
            this.trk_sclX.Size = new System.Drawing.Size(135, 45);
            this.trk_sclX.TabIndex = 1;
            this.trk_sclX.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // trk_sclZ
            // 
            this.trk_sclZ.Location = new System.Drawing.Point(32, 105);
            this.trk_sclZ.Maximum = 5;
            this.trk_sclZ.Name = "trk_sclZ";
            this.trk_sclZ.Size = new System.Drawing.Size(135, 45);
            this.trk_sclZ.TabIndex = 6;
            this.trk_sclZ.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Y";
            // 
            // trk_sclY
            // 
            this.trk_sclY.Location = new System.Drawing.Point(32, 63);
            this.trk_sclY.Maximum = 5;
            this.trk_sclY.Name = "trk_sclY";
            this.trk_sclY.Size = new System.Drawing.Size(135, 45);
            this.trk_sclY.TabIndex = 4;
            this.trk_sclY.TickStyle = System.Windows.Forms.TickStyle.None;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lst_objects);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(215, 680);
            this.panel2.TabIndex = 13;
            // 
            // lst_objects
            // 
            this.lst_objects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst_objects.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem2});
            this.lst_objects.Location = new System.Drawing.Point(0, 0);
            this.lst_objects.MultiSelect = false;
            this.lst_objects.Name = "lst_objects";
            this.lst_objects.Size = new System.Drawing.Size(215, 680);
            this.lst_objects.TabIndex = 0;
            this.lst_objects.UseCompatibleStateImageBehavior = false;
            this.lst_objects.View = System.Windows.Forms.View.List;
            this.lst_objects.ItemActivate += new System.EventHandler(this.lst_objects_ItemActivate);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addObjectsToolStripMenuItem,
            this.visibilityModeToolStripMenuItem,
            this.shaderToolStripMenuItem,
            this.cameraModeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(933, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addObjectsToolStripMenuItem
            // 
            this.addObjectsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cubeToolStripMenuItem,
            this.uploadObjToolStripMenuItem});
            this.addObjectsToolStripMenuItem.Name = "addObjectsToolStripMenuItem";
            this.addObjectsToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.addObjectsToolStripMenuItem.Text = "Add Objects";
            // 
            // cubeToolStripMenuItem
            // 
            this.cubeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cubeToolStripMenuItem1,
            this.ballToolStripMenuItem,
            this.prismBallToolStripMenuItem});
            this.cubeToolStripMenuItem.Name = "cubeToolStripMenuItem";
            this.cubeToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.cubeToolStripMenuItem.Text = "Primitive";
            // 
            // cubeToolStripMenuItem1
            // 
            this.cubeToolStripMenuItem1.Name = "cubeToolStripMenuItem1";
            this.cubeToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.cubeToolStripMenuItem1.Text = "Cube";
            this.cubeToolStripMenuItem1.Click += new System.EventHandler(this.cubeToolStripMenuItem1_Click);
            // 
            // ballToolStripMenuItem
            // 
            this.ballToolStripMenuItem.Name = "ballToolStripMenuItem";
            this.ballToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.ballToolStripMenuItem.Text = "Ball";
            this.ballToolStripMenuItem.Click += new System.EventHandler(this.ballToolStripMenuItem_Click);
            // 
            // prismBallToolStripMenuItem
            // 
            this.prismBallToolStripMenuItem.Name = "prismBallToolStripMenuItem";
            this.prismBallToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.prismBallToolStripMenuItem.Text = "Prism Ball";
            this.prismBallToolStripMenuItem.Click += new System.EventHandler(this.prismBallToolStripMenuItem_Click);
            // 
            // uploadObjToolStripMenuItem
            // 
            this.uploadObjToolStripMenuItem.Name = "uploadObjToolStripMenuItem";
            this.uploadObjToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.uploadObjToolStripMenuItem.Text = "Upload obj";
            this.uploadObjToolStripMenuItem.Click += new System.EventHandler(this.uploadObjToolStripMenuItem_Click);
            // 
            // visibilityModeToolStripMenuItem
            // 
            this.visibilityModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wireframeToolStripMenuItem});
            this.visibilityModeToolStripMenuItem.Name = "visibilityModeToolStripMenuItem";
            this.visibilityModeToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.visibilityModeToolStripMenuItem.Text = "Visibility Mode";
            // 
            // wireframeToolStripMenuItem
            // 
            this.wireframeToolStripMenuItem.CheckOnClick = true;
            this.wireframeToolStripMenuItem.Name = "wireframeToolStripMenuItem";
            this.wireframeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.wireframeToolStripMenuItem.Text = "Wireframe";
            this.wireframeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.wireframeToolStripMenuItem_CheckedChanged);
            // 
            // shaderToolStripMenuItem
            // 
            this.shaderToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smoothVSToolStripMenuItem,
            this.smoothFSToolStripMenuItem});
            this.shaderToolStripMenuItem.Name = "shaderToolStripMenuItem";
            this.shaderToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.shaderToolStripMenuItem.Text = "Shader";
            // 
            // smoothVSToolStripMenuItem
            // 
            this.smoothVSToolStripMenuItem.Name = "smoothVSToolStripMenuItem";
            this.smoothVSToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.smoothVSToolStripMenuItem.Text = "Smooth VS";
            this.smoothVSToolStripMenuItem.Click += new System.EventHandler(this.smoothVSToolStripMenuItem_Click);
            // 
            // smoothFSToolStripMenuItem
            // 
            this.smoothFSToolStripMenuItem.Name = "smoothFSToolStripMenuItem";
            this.smoothFSToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.smoothFSToolStripMenuItem.Text = "Smooth FS";
            this.smoothFSToolStripMenuItem.Click += new System.EventHandler(this.smoothFSToolStripMenuItem_Click);
            // 
            // cameraModeToolStripMenuItem
            // 
            this.cameraModeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prespectiveToolStripMenuItem,
            this.parallelToolStripMenuItem});
            this.cameraModeToolStripMenuItem.Name = "cameraModeToolStripMenuItem";
            this.cameraModeToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.cameraModeToolStripMenuItem.Text = "Camera Mode";
            // 
            // prespectiveToolStripMenuItem
            // 
            this.prespectiveToolStripMenuItem.Name = "prespectiveToolStripMenuItem";
            this.prespectiveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.prespectiveToolStripMenuItem.Text = "Prespective";
            this.prespectiveToolStripMenuItem.Click += new System.EventHandler(this.prespectiveToolStripMenuItem_Click);
            // 
            // parallelToolStripMenuItem
            // 
            this.parallelToolStripMenuItem.Name = "parallelToolStripMenuItem";
            this.parallelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.parallelToolStripMenuItem.Text = "Parallel";
            this.parallelToolStripMenuItem.Click += new System.EventHandler(this.parallelToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "obj";
            this.openFileDialog1.FileName = "object";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 704);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_clrR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_clrB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_clrG)).EndInit();
            this.grp_position.ResumeLayout(false);
            this.grp_position.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_posX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_posZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_posY)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_rotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_rotZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_rotY)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trk_sclX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_sclZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trk_sclY)).EndInit();
            this.panel2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox grp_position;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar trk_posX;
        private System.Windows.Forms.TrackBar trk_posZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trk_posY;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar trk_rotX;
        private System.Windows.Forms.TrackBar trk_rotZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TrackBar trk_rotY;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TrackBar trk_sclX;
        private System.Windows.Forms.TrackBar trk_sclZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TrackBar trk_sclY;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ListView lst_objects;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trk_clrR;
        private System.Windows.Forms.TrackBar trk_clrB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar trk_clrG;
        private System.Windows.Forms.ToolStripMenuItem addObjectsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cubeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ballToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prismBallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadObjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visibilityModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wireframeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shaderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothVSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smoothFSToolStripMenuItem;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.ToolStripMenuItem cameraModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prespectiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parallelToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

