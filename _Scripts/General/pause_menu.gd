extends Control

func resume():
	get_tree().paused = false
	
func pause():
	get_tree().paused = true
	

func testEsc():
	if Input.is_action_just_pressed("back") and !get_tree().paused:
		pause()
	elif Input.is_action_just_pressed("back") and get_tree().paused:
		resume()


func _on_resume_pressed():
	resume()


func _on_exit_pressed():
	get_tree().quit(0)
	
func _process(delta):
	testEsc()
