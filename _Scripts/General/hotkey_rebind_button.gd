extends Control

@onready var label = $HBoxContainer/Label
@onready var button = $HBoxContainer/Button

@export var action_name: String = "move_left"

# Llamado cuando el nodo entra en el árbol de la escena.
func _ready():
	set_process_unhandled_key_input(false)
	set_action_name()
	set_text_for_key()

# Asigna el texto al label basado en la acción.
func set_action_name() -> void:
	label.text = "Unassigned"
	
	match action_name:
		"move_left": label.text = "Move Left"
		"move_right": label.text = "Move Right"
		"move_approach": label.text = "Move Approach"
		"move_away": label.text = "Move Away"
		"move_up": label.text = "Up"
		"move_down": label.text = "Down"
		"attack": label.text = "Attack"
		"interactive": label.text = "Interact"
		"sonar": label.text = "Sonar"
		"accept": label.text = "Accept"
		"back": label.text = "Back"

# Actualiza el texto del botón según la tecla asignada.
func set_text_for_key() -> void:
	var action_events = InputMap.action_get_events(action_name)
	if action_events.size() > 0 and action_events[0] is InputEventKey:
		var action_keycode = OS.get_keycode_string(action_events[0].physical_keycode)
		button.text = "%s" % action_keycode
	else:
		button.text = "Unassigned"

# Maneja la lógica cuando el botón es presionado.
func _on_button_toggled(button_pressed: bool):
	if button_pressed:
		button.text = "Press any key..."
		set_process_unhandled_key_input(true)
		
		for i in get_tree().get_nodes_in_group("hotkey_button"):
			if i.action_name != self.action_name:
				i.button.toggle_mode = false
				i.set_process_unhandled_key_input(false)
	else:
		for i in get_tree().get_nodes_in_group("hotkey_button"):
			if i.action_name != self.action_name:
				i.button.toggle_mode = true
				i.set_process_unhandled_key_input(false)
		
		set_text_for_key()

# Rebind de la tecla al presionar una nueva.
func _unhandled_key_input(event: InputEvent):
	if event is InputEventKey and event.pressed:
		rebind_action_key(event)
		button.toggle_mode = true

func rebind_action_key(event: InputEvent) -> void:
	InputMap.action_erase_events(action_name)
	InputMap.action_add_event(action_name, event)
	set_process_unhandled_key_input(false)
	set_text_for_key()
	set_action_name()
