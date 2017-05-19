#version 330
in vec4 color;

void main()
{
	gl_FragColor=color;
	
	//gl_FragColor=vec4(0,1,1,1);
	//if(fPos.x>0)
		//gl_FragColor=vec4(0,1,0,1);
	//else
		//gl_FragColor=vec4(0,0,1,1);

	//gl_FragColor=fPos;
}