using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _42
{
    //enum Status
    //{
    //    Valid = 0,
    //    VxShader = 1,
    //    FgShader = 2,
    //    Link = 4
    //}
    class Shader :IDisposable
    {
        int programID;
        private Shader(int programID)
        {
            this.programID = programID;
        }
        public static Shader CreateShader(string VertexShaderName, string FragmentShaderName)
        {
            int pID = initShader(VertexShaderName, FragmentShaderName);
            if (pID != -1)
	        {
                return new Shader(pID);
	        }
            return null;
        }
        static int initShader(string VertexShaderName, string FragmentShaderName)
        {
            int vertexShaderID = CompileShader(VertexShaderName, ShaderType.VertexShader);
            int fragmentShaderID = CompileShader(FragmentShaderName, ShaderType.FragmentShader);
            if (vertexShaderID == -1 || fragmentShaderID == -1)
            {
                return -1;
            }
            int pID = GL.CreateProgram();
            GL.AttachShader(pID, vertexShaderID);
            GL.AttachShader(pID, fragmentShaderID);

            GL.LinkProgram(pID);
            int result;
            GL.GetProgram(pID, GetProgramParameterName.LinkStatus, out result);
            if (result == 0)
                return -1;
            return pID;
         }
        public void UseShader()
        {
            GL.UseProgram(programID);
        }
        public void UnUseShader()
        {
            GL.UseProgram(-1);
        }
        static int CompileShader(string filename, ShaderType type)
        {
            int shaderid = GL.CreateShader(type);
            using (StreamReader sr = new StreamReader(filename))
            {
                string shaderSource = sr.ReadToEnd();
                GL.ShaderSource(shaderid, shaderSource);
            }
            GL.CompileShader(shaderid);
            int result;
            GL.GetShader(shaderid, ShaderParameter.CompileStatus, out result);
            Console.WriteLine(GL.GetShaderInfoLog(shaderid));
            if (result == 1)
                return shaderid;
            else
                return -1;
        }     
        public int GetUniformLocation(string UniformName){
            return GL.GetUniformLocation(programID, UniformName);
        }
        public int GetAttribLocation(string AttributeName)
        {
            return GL.GetAttribLocation(programID, AttributeName);
        }
        public void Dispose()
        {
            GL.DeleteProgram(programID);
        }
    }
}
