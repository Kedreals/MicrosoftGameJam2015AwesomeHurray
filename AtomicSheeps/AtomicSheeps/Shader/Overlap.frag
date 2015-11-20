uniform sampler2D texture;

uniform sampler2D overlay;

void main(void)
{
	vec2 texCoord = gl_TexCoord[0].xy;

	gl_FragColor = texture2D(texture, texCoord) * texture2D(overlay, texCoord);
}