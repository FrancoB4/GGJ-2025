extends CharacterBody3D

const speed = 10.0
const rise_force = 15.0
const gravity = -9.8

var wait_animation:bool = false

func _physics_process(delta):
	velocity.x = 0
	velocity.z = 0

	# Movimiento en el plano XZ
	if Input.is_action_pressed("move_forward"):
		velocity.z -= speed
	if Input.is_action_pressed("move_backward"):
		velocity.z += speed
	if Input.is_action_pressed("move_left"):
		velocity.x -= speed
	if Input.is_action_pressed("move_right"):
		velocity.x += speed
	
	if Input.is_action_pressed("jump"):
		velocity.y += rise_force
		wait_animation = false
	else:
		velocity.y += gravity * delta
	
	if is_on_floor():
		velocity.y = 0
	
	move_and_slide()
	

func select_animation():
	if wait_animation:
		if velocity.x == 0:
			$AnimatedSprite2D.play("idle")
		elif velocity.x < 0:
			$AnimatedSprite2D.flip_h = true
			$AnimatedSprite2D.play("run")
		elif velocity.x > 0:
			$AnimatedSprite2D.flip_h = false
			$AnimatedSprite2D.play("run")

func _on_animated_sprite_2d_animation_finished():
	wait_animation = true
