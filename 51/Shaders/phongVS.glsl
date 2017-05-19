#version 330
in vec3 vertex_position;
in vec3 vertex_normal;
in vec2 vertex_uv;

uniform vec3 camPos;

uniform mat4 modelMat;
uniform mat4 viewMat;
uniform mat4 projMat;


uniform vec3 MatColor;
uniform vec3 SpecColor;

uniform float lightInt;
uniform float ka;
uniform float kd;
uniform float ks;
uniform float alpha;

vec3 lightDir = vec3(1,1,1);
out vec3 fColor;

void main()
{
	gl_Position = projMat * viewMat * modelMat * vec4(vertex_position,1);
	vec3 n = mat3(modelMat) * normalize(vertex_normal);
	vec3 l = normalize(lightDir);
	vec3 v = camPos - (modelMat * vec4(vertex_position,1)).xyz;
	vec3 h=normalize(v+l);
	float diff=ka+kd*lightInt*max(0,dot(l,n));
	float spec=ks*pow(max(dot(h,n),0),alpha);
	if(dot(l,n)<=0)
		spec=0;
	fColor= MatColor * diff + spec * SpecColor;

}