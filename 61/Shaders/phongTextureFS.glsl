#version 330
in vec3 frag_position;
in vec3 frag_normal;
in vec2 frag_uv;
in mat4 modelMatrix;

uniform sampler2D colorMap; // MatColor
uniform vec3 SpecColor;

uniform vec3 camPos;

uniform float lightInt;
uniform float ka;
uniform float kd;
uniform float ks;
uniform float alpha;

vec3 lightDir = vec3(1,1,1);

uniform float tileX;
uniform float tileY;

void main()
{
	vec3 n = mat3(modelMatrix) * normalize(frag_normal);
	vec3 l = normalize(lightDir);
	vec3 v = camPos - (modelMatrix * vec4(frag_position,1)).xyz;
	vec3 h=normalize(v+l);
	float diff=ka+kd*lightInt*max(0,dot(l,n));
	float spec=ks*pow(max(dot(h,n),0),alpha);
	if(dot(l,n)<=0)
		spec=0;


	//vec2 longitudeLatitude = vec2((atan(frag_position.y, frag_position.x) / 3.1415926 + 1.0) * 0.5,(asin(frag_position.z) / 3.1415926 + 0.5));
	gl_FragColor = vec4(((texture2D(colorMap,vec2(frag_uv.x*tileX,frag_uv.y*tileY))).xyz) * diff + spec * SpecColor , 1);

}