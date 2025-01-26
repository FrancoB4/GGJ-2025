extends Control

@onready var Resume_button = $MarginContainer/VBoxContainer/Resume as Button
@onready var Exit_button = $MarginContainer/VBoxContainer/Exit as Button
@onready var Menu = $"." as Control

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if(Input.is_action_just_pressed("back")):
		Menu.visible = false
	

func _on_resume_pressed():
	Menu.visible = false

func _on_exit_pressed():
	get_tree().change_scene_to_file("res://Escenas/Niveles/Main_Menu.tscn")
