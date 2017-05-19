#version 330
in vec3 vertex_position;
in vec3 vertex_normal;
in vec2 vertex_uv;

uniform mat4 modelMat;
uniform mat4 viewMat;
uniform mat4 projMat;

out mat4 modelMatrix;
out vec3 frag_position;
out vec3 frag_normal;
out vec2 frag_uv;

void main()
{
	gl_Position = projMat * viewMat * modelMat * vec4(vertex_position,1);

	frag_position = vertex_position;
	frag_normal = vertex_normal;
	frag_uv = vertex_uv;
	modelMatrix = modelMat;
}