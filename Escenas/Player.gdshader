shader_type canvas_item;

uniform vec4 water_color : hint_color = vec4(0.0, 0.4, 0.6, 0.5); // Color del agua
uniform float distortion_strength : hint_range(0.0, 1.0) = 0.2; // Fuerza de distorsión

void fragment() {
    vec2 uv = FRAGCOORD.xy / SCREEN_PIXEL_SIZE;

    // Distorsion del agua
    vec2 offset = vec2(sin(uv.y * 10.0 + TIME) * distortion_strength, cos(uv.x * 10.0 + TIME) * distortion_strength);
    uv += offset;

    // Aplicamos el color del agua con distorsión
    vec4 col = texture(TEXTURE, uv);
    col.rgb = mix(col.rgb, water_color.rgb, water_color.a);
    
    COLOR = col;
}
