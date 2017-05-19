

#version 330
in vec4 vertex_position;//location = 0
in vec4 vertex_color;// location = 1

out vec4 color;

//uniform float theta;//location

uniform mat4 modelMat;

void main()
{
	//float theta=3.14/4;

	//float x = vertex_position.x * cos(theta) - vertex_position.y * sin(theta);
	//float y=vertex_position.x*sin(theta)+vertex_position.y*cos(theta);
	gl_Position=modelMat*vec4(vertex_position.xyz,1);
	color=vertex_color;
}