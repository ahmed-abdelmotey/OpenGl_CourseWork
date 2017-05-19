#version 330
in vec2 frag_uv;
in vec3 fColor;

uniform sampler2D colorMap;


uniform float tileX;
uniform float tileY;

void main()
{

	gl_FragColor = texture2D(colorMap,vec2(frag_uv.x*tileX,frag_uv.y*tileY));

}