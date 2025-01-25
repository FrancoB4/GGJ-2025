shader_type canvas_item;

uniform vec4 center_color : source_color = vec4(1.0, 1.0, 1.0, 1.0); // Color del centro
uniform vec4 edge_color : source_color = vec4(0.0, 0.0, 0.0, 1.0);   // Color de los bordes (negro por defecto)
uniform float radius : hint_range(0.0, 1.0) = 0.5;                    // Radio del área clara
uniform float softness : hint_range(0.0, 1.0) = 0.3;
uniform float effect_strength : hint_range(0.0, 1.0) = 0.0;

void fragment()
{
    // Coordenadas UV centradas (0,0 en el centro de la pantalla)
    vec2 uv = UV - vec2(0.5);
    
    // Distancia del píxel al centro
    float dist = length(uv) / sqrt(0.5); // Normalizar la distancia para ajustarla al tamaño del rectángulo
    
    // Factor de mezcla para suavizar la transición
    float blend = smoothstep(radius, radius + softness, dist);
	
	// Mezclar entre el color del centro y el color del borde
    vec4 final_color = mix(center_color, edge_color, blend);
    
    // Mezclar entre el color del centro y el color de los bordes
    COLOR = mix(center_color, final_color, effect_strength);
}
