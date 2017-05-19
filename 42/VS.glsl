#version 330

in vec2 vertex_position;//location = 0


void main()
{
	gl_Position=vec4(vertex_position,0,1);
}