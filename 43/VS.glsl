#version 330

uniform float dx;
in float vertex_x;//location = 0


void main()
{
	gl_Position = vec4(vertex_x,sin(vertex_x*3+dx),0,1);
}