﻿#version 330
in vec3 vertex_position;

uniform mat4 modelMat;
uniform mat4 viewMat;
uniform mat4 projMat;

void main()
{
	gl_Position = projMat * viewMat * modelMat * vec4(vertex_position,1);
}