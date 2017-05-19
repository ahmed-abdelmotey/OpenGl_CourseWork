#version 330
in vec3 frag_position;
in vec3 frag_normal;

in mat4 modelMatrix;

uniform vec3 camPos;

uniform vec3 MatColor;
uniform vec3 SpecColor;

uniform float lightInt;
uniform float ka;
uniform float kd;
uniform float ks;
uniform float alpha;

vec3 lightDir = vec3(5,5,5);


void main()
{
	vec3 n = inverse (transpose ( mat3(modelMatrix))) * normalize(frag_normal);
	vec3 l = normalize(lightDir);
	vec3 v = camPos - (modelMatrix * vec4(frag_position,1)).xyz;
	vec3 h=normalize(v+l);
	float diff=ka+kd*lightInt*max(0,dot(l,n));
	float spec=ks*pow(max(dot(h,n),0),alpha);
	if(dot(l,n)<=0)
		spec=0;

	gl_FragColor = vec4(MatColor * diff + spec * SpecColor , 1);

}