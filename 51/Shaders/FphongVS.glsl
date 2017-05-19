#version 330
in vec3 vertex_position;
in vec3 vertex_normal;

uniform mat4 modelMat;
uniform mat4 viewMat;
uniform mat4 projMat;

out mat4 modelMatrix;
out vec3 frag_position;
out vec3 frag_normal;

void main()
{
	gl_Position = projMat * viewMat * modelMat * vec4(vertex_position,1);

	frag_position = vertex_position;
	frag_normal = vertex_normal;
	modelMatrix = modelMat;
}