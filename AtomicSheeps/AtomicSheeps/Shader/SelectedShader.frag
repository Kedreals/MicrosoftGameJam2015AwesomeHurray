uniform sampler2D texture;

void main(void)
{
	vec2 texCoord = gl_TexCoord[0].xy;

	vec4 color = texture2D(texture, texCoord);

	gl_FragColor = color + vec4(255, 0, 0, 0);
}