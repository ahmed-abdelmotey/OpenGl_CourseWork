using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Graphics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Project
{
    class Mesh
    {
        #region LocalVariables
        int VertexBufferID;
        int IndexBufferID;

        Vertex[] vertices;
        int[] indices;

        Matrix4 modelMat;

        PrimitiveType primitiveType;

        public Shader Shader { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 Scale { get; set; }
        public Vector3 Rotation { get; set; }
        #endregion
        #region Material Parameters
        int TextureId = -1;
        public Vector4 MatColor { get; set; }
        public Vector4 SpecColor { get; set; }
        public float LightInt { get; set; }
        public float KA { get; set; }
        public float KD { get; set; }
        public float KS { get; set; }
        public float Alpha { get; set; }
        public float TileX { get; set; }
        public float TileY { get; set; }
        #endregion
        #region Constructors
        void InitializeBuffers()
        {
            // Vertix Buffer Array
            VertexBufferID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferID);
            GL.BufferData<Vertex>(BufferTarget.ArrayBuffer,(IntPtr) (vertices.Length * Vertex.SizeInBytes), vertices, BufferUsageHint.StaticDraw);

            // Index Buffer Array
            IndexBufferID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferID);
            GL.BufferData<int>(BufferTarget.ElementArrayBuffer, (IntPtr) (indices.Length * sizeof(int)), indices, BufferUsageHint.StaticDraw);

        }
        public Mesh(Shader shader, PrimitiveType primitiveType , Vertex[] vertices, int[] indices, Vector3 position, Vector3 Scale, Vector3 Rotation,Vector4 MatColor,Vector4 SpecColor)
        {
            // initialize local variables
            this.Position = position;
            this.Scale = Scale;
            this.Rotation = Rotation;

            this.vertices = vertices;
            this.MatColor = MatColor;
            this.SpecColor = SpecColor;
            this.Shader = shader;
            this.primitiveType = primitiveType;

            LightInt = 1.0f;
            KA = 0.2f;
            KD = 0.4f;
            KS = 0.7f;
            Alpha = 30;

            TileX = TileY = 1;

            // initialize indices array
            if (indices == null)
            {
                this.indices = new int[vertices.Length];
                for (int i = 0; i < vertices.Length; i++)
                {
                    this.indices[i] = i;
                }
            }
            else
            {
                this.indices = indices;
            }
            InitializeBuffers();
        }
        public Mesh(Shader shader, PrimitiveType primitiveType, Vertex[] vertices, Vector3 position, Vector3 Scale, Vector3 Rotation, Vector4 MatColor, Vector4 SpecColor)
            : this(shader, primitiveType, vertices, null, position, Scale, Rotation, MatColor, SpecColor) { }
        public Mesh(Shader shader, PrimitiveType primitiveType, Vertex[] vertices, int[] indices, Vector4 MatColor, Vector4 SpecColor) 
            : this(shader, primitiveType, vertices, indices, Vector3.Zero, Vector3.Zero, Vector3.Zero, MatColor, SpecColor) { }
        public Mesh(Shader shader, PrimitiveType primitiveType, Vertex[] vertices, Vector4 MatColor, Vector4 SpecColor)
            : this(shader, primitiveType, vertices, null, Vector3.Zero, Vector3.Zero, Vector3.Zero, MatColor, SpecColor) { }
        public Mesh(Shader shader, PrimitiveType primitiveType, Vertex[] vertices, Vector4 MatColor)
            : this(shader, primitiveType, vertices, null, Vector3.Zero, Vector3.Zero, Vector3.Zero, MatColor, new Vector4(0.1f, 0.1f, 0.1f, 1)) { }
        public Mesh(Shader shader, PrimitiveType primitiveType, Vertex[] vertices, int[] indices, Vector4 MatColor)
            : this(shader, primitiveType, vertices, indices, Vector3.Zero, Vector3.Zero, Vector3.Zero, MatColor, new Vector4(0.1f, 0.1f, 0.1f, 1)) { }
        public Mesh(Shader shader, PrimitiveType primitiveType, Vertex[] vertices, int[] indices)
            : this(shader, primitiveType, vertices, indices, Vector3.Zero, Vector3.Zero, Vector3.Zero, new Vector4(0.8f, 0.8f, 0.8f, 1), new Vector4(0.1f, 0.1f, 0.1f, 1)) { }
        public Mesh(Shader shader, PrimitiveType primitiveType, Vertex[] vertices)
            : this(shader, primitiveType, vertices, null, Vector3.Zero, Vector3.Zero, Vector3.Zero, new Vector4(0.8f, 0.8f, 0.8f, 1), new Vector4(0.1f, 0.1f, 0.1f, 1)) { }
        #endregion
        #region Set Texture
        int LoadImageToVRAM(string filename)
        {
            Bitmap bmp = new Bitmap(filename);
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            int textureId = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, textureId);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, bmp.Width, bmp.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bmpData.Scan0);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)(TextureMinFilter.Linear));
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)(TextureMagFilter.Linear));
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)(TextureWrapMode.Repeat));
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)(TextureWrapMode.Repeat));

            return textureId;
        }
        public void AddTextureFromFile(string filename)
        {
            this.TextureId = LoadImageToVRAM(filename);
        }
        #endregion
        #region Render
        public void Render(Camera cam, bool isWireframe)
        {
            // use shader
            Shader.UseShader();
            
            // send uniforms to VS
            Matrix4 viewMat = cam.ViewMatrix;
            Matrix4 projMat = cam.ProjMatrix;
            Vector3 camPos = cam.Position;

            // calculate model mat
            modelMat = Matrix4.Identity;
            if (Rotation != Vector3.Zero)
            {
                modelMat *= Matrix4.CreateRotationX(Rotation.X) * Matrix4.CreateRotationY(Rotation.Y) * Matrix4.CreateRotationZ(Rotation.Z);
            }
            if (Scale != Vector3.Zero)
            {
                modelMat *= Matrix4.CreateScale(Scale);
            }
            if (Position != Vector3.Zero)
            {
                modelMat *= Matrix4.CreateTranslation(Position);
            }

            // Assign Uniforms
            GL.UniformMatrix4(Shader.GetUniformLocation("modelMat"), false, ref modelMat);
            GL.UniformMatrix4(Shader.GetUniformLocation("viewMat"), false, ref viewMat);
            GL.UniformMatrix4(Shader.GetUniformLocation("projMat"), false, ref projMat);

            GL.Uniform3(Shader.GetUniformLocation("MatColor"), MatColor.Xyz);
            GL.Uniform3(Shader.GetUniformLocation("SpecColor"), SpecColor.Xyz);

            GL.Uniform1(Shader.GetUniformLocation("lightInt"), LightInt);
            GL.Uniform1(Shader.GetUniformLocation("ka"), KA);
            GL.Uniform1(Shader.GetUniformLocation("kd"), KD);
            GL.Uniform1(Shader.GetUniformLocation("ks"), KS);
            GL.Uniform1(Shader.GetUniformLocation("alpha"), Alpha);

            GL.Uniform1(Shader.GetUniformLocation("tileX"), TileX);
            GL.Uniform1(Shader.GetUniformLocation("tileY"), TileY);

            GL.Uniform3(Shader.GetUniformLocation("camPos"), camPos);

            // bind buffers
            GL.BindBuffer(BufferTarget.ArrayBuffer, VertexBufferID);
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, IndexBufferID);
            if (TextureId != -1)
            {
                GL.BindTexture(TextureTarget.Texture2D, TextureId);
            }

            // fetch data from buffers
            int vertexPositionLoc = Shader.GetAttribLocation("vertex_position");
            GL.VertexAttribPointer(vertexPositionLoc, 3, VertexAttribPointerType.Float, false, Vertex.SizeInBytes, 0);
            GL.EnableVertexAttribArray(vertexPositionLoc);

            int vertexNormalLoc = Shader.GetAttribLocation("vertex_normal");
            GL.VertexAttribPointer(vertexNormalLoc, 3, VertexAttribPointerType.Float, false, Vertex.SizeInBytes, Vector3.SizeInBytes);
            GL.EnableVertexAttribArray(vertexNormalLoc);

            int vertexUVLoc = Shader.GetAttribLocation("vertex_uv");
            GL.VertexAttribPointer(vertexUVLoc, 2, VertexAttribPointerType.Float, false, Vertex.SizeInBytes, Vector3.SizeInBytes * 2);
            GL.EnableVertexAttribArray(vertexUVLoc);

            // Render Style
            if (!isWireframe)
            {
                GL.LineWidth(1);                
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);                
                GL.DrawElements(primitiveType, indices.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
            }
            else
            {
                GL.LineWidth(3);
                GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
                GL.DrawElements(primitiveType, indices.Length, DrawElementsType.UnsignedInt, IntPtr.Zero);
            }

            Shader.UnUseShader();
        }
        #endregion
        #region Static CreateMeshes
        public static Mesh CreateGrid(Shader shader, int limit, int spacing, Vector4 color)
        {
            Vertex[] vertices = new Vertex[limit * 8 + 4];
            // calculate possitions of grid lines
            int i = 0;
            for (int d = -1 * limit; d <= limit; d += spacing)
            {
                vertices[i++] = new Vertex(new Vector3(d, 0, limit * -1));
                vertices[i++] = new Vertex(new Vector3(d, 0, limit));
                vertices[i++] = new Vertex(new Vector3(limit * -1, 0, d));
                vertices[i++] = new Vertex(new Vector3(limit, 0, d));
            }
            return new Mesh(shader,PrimitiveType.Lines,vertices,color);
        }
        public static Mesh CreateQuad(Shader shader, float x, float y, float z)
        {
            Vertex[] vertices = new Vertex[4];

            vertices[0] = new Vertex(new Vector3(-1 * x, y, -1 * z), Vector3.UnitY, new Vector2(0, 1));
            vertices[1] = new Vertex(new Vector3(-1 * x, y, z), Vector3.UnitY, new Vector2(0, 0));
            vertices[2] = new Vertex(new Vector3(x, y, -1 * z), Vector3.UnitY, new Vector2(1, 1));
            vertices[3] = new Vertex(new Vector3(x, y, z), Vector3.UnitY, new Vector2(1, 0));

            int[] indices = { 0, 1, 2, 2, 1, 3 };
            return new Mesh(shader, PrimitiveType.Triangles, vertices,indices,new Vector4(0.5f,0.5f,0.5f,1));
        }
        public static Mesh CreateCube(Shader shader, float Width, float Height, float Depth , Vector4 Color)
        {
            int[] indices = new int[36];
            Vertex[] vertices =
            {
                new Vertex(new Vector3(Width/-2, Height/ 2, Depth/ 2) , new Vector3(Width/-2, Height/ 2, Depth/ 2)),
                new Vertex(new Vector3(Width/-2, Height/-2, Depth/ 2) , new Vector3(Width/-2, Height/-2, Depth/ 2)),
                new Vertex(new Vector3(Width/ 2, Height/-2, Depth/ 2) , new Vector3(Width/ 2, Height/-2, Depth/ 2)),
                new Vertex(new Vector3(Width/ 2, Height/ 2, Depth/ 2) , new Vector3(Width/ 2, Height/ 2, Depth/ 2)),
                                                                      
                new Vertex(new Vector3(Width/ 2, Height/ 2, Depth/-2) , new Vector3(Width/ 2, Height/ 2, Depth/-2)),
                new Vertex(new Vector3(Width/ 2, Height/-2, Depth/-2) , new Vector3(Width/ 2, Height/-2, Depth/-2)),
                new Vertex(new Vector3(Width/-2, Height/-2, Depth/-2) , new Vector3(Width/-2, Height/-2, Depth/-2)),
                new Vertex(new Vector3(Width/-2, Height/ 2, Depth/-2) , new Vector3(Width/-2, Height/ 2, Depth/-2))
            };
            // Generate Faces Indices
            
            Quad(ref indices, 0, 0, 1, 2, 3);
            Quad(ref indices, 1, 3, 2, 5, 4);
            Quad(ref indices, 2, 4, 5, 6, 7);
            Quad(ref indices, 3, 0, 7, 6, 1);
            Quad(ref indices, 4, 7, 0, 3, 4);
            Quad(ref indices, 5, 1, 6, 5, 2);
                              
            return new Mesh(shader, PrimitiveType.Triangles, vertices, indices, Color);
        }
        static void Quad(ref int[] indices, int start, int a, int b, int c, int d)
        {
            // Generate face for cube
            int i = start * 6;

            indices[i]   = a;
            indices[i+1] = b;
            indices[i+2] = d;
            indices[i+3] = d;
            indices[i+4] = b;
            indices[i+5] = c;

        }
        public static Mesh CreateSphere(Shader shader, float radius, int longitude, int latitude)
        {
            float delTheta = (float)(Math.PI * 2 / longitude);
            float delPhi = (float)(Math.PI / latitude);
            float rad = radius;
            List<Vertex> vertices = new List<Vertex>();
            List<int> indices = new List<int>();         
            int i = 0;
            for (float phi = 0; phi < Math.PI; phi += delPhi)
            {
                for (float theta = 0; theta <= 2 * Math.PI; theta += delTheta)
                {
                    float theta2 = theta + delTheta;
                    float phi2 = phi + delPhi;

                    float x1 = (float)(rad * Math.Cos(theta) * Math.Sin(phi));
                    float z1 = (float)(rad * Math.Sin(theta) * Math.Sin(phi));
                    float y1 = (float)(rad * Math.Cos(phi));

                    float x2 = (float)(rad * Math.Cos(theta) * Math.Sin(phi2));
                    float z2 = (float)(rad * Math.Sin(theta) * Math.Sin(phi2));
                    float y2 = (float)(rad * Math.Cos(phi2));

                    float x3 = (float)(rad * Math.Cos(theta2) * Math.Sin(phi));
                    float z3 = (float)(rad * Math.Sin(theta2) * Math.Sin(phi));
                    float y3 = (float)(rad * Math.Cos(phi));

                    float x4 = (float)(rad * Math.Cos(theta2) * Math.Sin(phi2));
                    float z4 = (float)(rad * Math.Sin(theta2) * Math.Sin(phi2));
                    float y4 = (float)(rad * Math.Cos(phi2));

                    vertices.Add(new Vertex(new Vector3(x1, y1, z1), new Vector3(x1, y1, z1), new Vector2((float)(Math.Atan2(y1, x1) / Math.PI + 1.0) * 0.5f, (float)(Math.Asin(z1) / Math.PI + 0.5f))));
                    vertices.Add(new Vertex(new Vector3(x2, y2, z2), new Vector3(x2, y2, z2), new Vector2((float)(Math.Atan2(y2, x2) / Math.PI + 1.0) * 0.5f, (float)(Math.Asin(z2) / Math.PI + 0.5f))));
                    vertices.Add(new Vertex(new Vector3(x3, y3, z3), new Vector3(x3, y3, z3), new Vector2((float)(Math.Atan2(y3, x3) / Math.PI + 1.0) * 0.5f, (float)(Math.Asin(z3) / Math.PI + 0.5f))));
                    vertices.Add(new Vertex(new Vector3(x4, y4, z4), new Vector3(x4, y4, z4), new Vector2((float)(Math.Atan2(y4, x4) / Math.PI + 1.0) * 0.5f, (float)(Math.Asin(z4) / Math.PI + 0.5f))));

                    indices.AddRange(new int[] { i, i + 1, i + 2, i + 2, i + 1, i + 3 });
                    
                    i += 4;
                }
            }

            return new Mesh(shader, PrimitiveType.Triangles, vertices.ToArray(), indices.ToArray(), new Vector4(1, 0.3f, 0.7f, 1), new Vector4(0, 0.3f, 0.7f, 1));
        }
        public static Mesh CreatePrismSphere(Shader shader, int iter)
        {
            List<Vertex> vertices = new List<Vertex>();            
            Vector3[] prism =
            {
                new Vector3(0,0,1),
                new Vector3(0,0.942809f,-0.333333f),
                new Vector3(-0.816497f,-0.471405f,-0.333333f),
                new Vector3(0.816497f,-0.471405f,-0.333333f)
            };

            divideTriangle(ref vertices,prism[0], prism[1], prism[2], iter);                          
            divideTriangle(ref vertices,prism[0], prism[3], prism[1], iter);                        
            divideTriangle(ref vertices,prism[0], prism[2], prism[3], iter);                       
            divideTriangle(ref vertices,prism[3], prism[2], prism[1], iter);

            return new Mesh(shader, PrimitiveType.Triangles, vertices.ToArray(), new Vector4(0.5f, 0.5f, 1, 1), new Vector4(0.3f,1, 0.3f, 1));
        }      
        static void divideTriangle(ref List<Vertex> sphereVertices,  Vector3 a, Vector3 b, Vector3 c, int iter)
        {
            // Divide triangles for PrismSphere
            if (iter == 0)
            {
                // flat shading
                //Vector3 faceNormal = Vector3.Normalize(Vector3.Cross(c - b, a - b));
                //sphereVertices.Add(new Vertex(a, faceNormal));
                //sphereVertices.Add(new Vertex(b, faceNormal));
                //sphereVertices.Add(new Vertex(c, faceNormal));

                // smoth shading
                sphereVertices.Add(new Vertex(a, a));
                sphereVertices.Add(new Vertex(b, b));
                sphereVertices.Add(new Vertex(c, c));

                // normal = zero
                //sphereVertices.Add(new Vertex(a));
                //sphereVertices.Add(new Vertex(b));
                //sphereVertices.Add(new Vertex(c));
            }
            else
            {
                Vector3 v1 = Vector3.Normalize((a + b));
                Vector3 v2 = Vector3.Normalize((b + c));
                Vector3 v3 = Vector3.Normalize((c + a));

                divideTriangle(ref sphereVertices, a, v1, v3, iter - 1);
                divideTriangle(ref sphereVertices, v1, b, v2, iter - 1);
                divideTriangle(ref sphereVertices, v1, v2, v3, iter - 1);
                divideTriangle(ref sphereVertices, v3, v2, c, iter - 1);
            }
        }
        public static Mesh LoadFromFile(string filePath , Shader shader)
        {
            #region ReadFile
            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length == 0)
            {
                return null;
            }
            #endregion
            #region Initialize Variables
            List<Vertex> vertices = new List<Vertex>();
            List<int> indices = new List<int>();

            List<Vector3> position = new List<Vector3>();
            List<Vector3> normal = new List<Vector3>();
            List<Vector2> UV = new List<Vector2>();           
            #endregion
            #region ParseLines
            List<string[]> faces = new List<string[]>();
            foreach (string line in lines)
            {
                string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length > 0)
                {
                    switch (parts[0])
                    {
                        //case "mtllib":
                        // read material library >> 
                        //    string _material = parts[1];
                        //    break;
                        case "v":
                            float[] pos = parts.Skip(1).Select(n => float.Parse(n)).ToArray();
                            position.Add(new Vector3(pos[0], pos[1], pos[2]));
                            break;
                        case "vn":
                            float[] norm = parts.Skip(1).Select(n => float.Parse(n)).ToArray();
                            normal.Add(new Vector3(norm[0], norm[1], norm[2]));
                            break;
                        case "vt":
                            float[] uv = parts.Skip(1).Select(n => float.Parse(n)).ToArray();
                            UV.Add(new Vector2(uv[0], uv[1]));
                            break;
                        case "f":
                            faces.Add(parts.Skip(1).ToArray());
                            break;
                    }
                }
            }
            #endregion
            #region ProcessFaces
            foreach (string[] face in faces)
            {
                foreach (string ver in face)
                {
                    int[] verind = ver.Split('/').Select(c => int.Parse(c)).ToArray();

                    // check what is provided in face and in obj file
                    if (verind.Length != 3)
                    {
                        Vector3 verNorm;
                        if (normal.Count == 0)
                        {
                            verNorm = Vector3.Zero;
                        }
                        else
                        {
                            verNorm = normal[verind[1] - 1];
                        }
                        Vector2 verUV;
                        if (normal.Count == 0)
                        {
                            verUV = Vector2.Zero;
                        }
                        else
                        {
                            verUV = UV[verind[2] - 1];
                        }
                        vertices.Add(new Vertex(position[verind[0] - 1], verNorm, verUV));
                    }
                    else
                    {
                        vertices.Add(new Vertex(position[verind[0] - 1], normal[verind[1] - 1], UV[verind[2] - 1]));
                    }
                }
                if (face.Length == 4)
                {
                    // make quad >> add 6 indicis 1 2 3 4 >> 1 2 4 4 2 3
                    indices.AddRange(new int[] { vertices.Count - 4, vertices.Count - 3, vertices.Count - 1, vertices.Count - 1, vertices.Count - 3, vertices.Count - 2 });
                }
                else if (face.Length == 3)
                {
                    // make triangle >> add 3 indicis
                    indices.AddRange(new int[] { vertices.Count - 3, vertices.Count - 2, vertices.Count - 1 });
                }
            }
            #endregion
            #region CreateMesh
            if (indices.Count != 0)
            {
                return new Mesh(shader, PrimitiveType.Triangles, vertices.ToArray(), indices.ToArray());
            }
            else
            {
                return null;
            }
            #endregion
        }
        #endregion      
    }
}
