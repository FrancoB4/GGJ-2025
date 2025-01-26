using Godot;
using System;

public partial class Movement : CharacterBody3D
{
	[Export]
	public float Speed = 5.0f; // Velocidad de movimiento
	public const float JumpVelocity = 5.0f; // Velocidad del salto
	public const float FloatVelocity = 0.0f; // Velocidad para mantener la altura
	public const float DescendVelocity = -5.0f; // Velocidad para descender
	public const float AscendRate = 1f;
	
	private bool isAttack = false;
	private const float VelocityAttack = 5.0f;
	private const float attackPower = 20f; // Potencia base del ataque
	
	private AnimatedSprite3D _animatedSprite3D;
	
	public override void _Ready()
	{
		_animatedSprite3D = GetNode<AnimatedSprite3D>("AnimatedSprite3D");
	}

	public override void _PhysicsProcess(double delta)
	{
		//Movimiento
		// Obtener la velocidad actual del personaje
		Vector3 velocity = Velocity;
		
		if (Input.IsActionPressed("move_up"))
		{
			// Subir cuando se presiona espacio
			velocity.Y = JumpVelocity;
			
		}
		else if (Input.IsActionPressed("move_down"))
		{
			// Bajar cuando se presiona shift
			velocity.Y = DescendVelocity;
			
		}
		else
		{
			// Mantenerse flotando si no se presiona nada
			velocity.Y = FloatVelocity;
		}
		
		if (IsOnFloor() || !IsOnFloor()){
			velocity.Y += AscendRate * (float)delta;
		}
		
		
		
		// Movimiento en el plano horizontal
		Vector2 inputDir = Input.GetVector("move_left", "move_right", "move_approach", "move_away");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		
		if(Input.IsActionPressed("attack"))
		{
			velocity.X += VelocityAttack * (float)delta;
			isAttack = true;
			
		}
		
		// Actualizar la velocidad en los ejes X y Z
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * Speed;
			velocity.Z = direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed * (float)delta);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed * (float)delta);
		}
		
		

		// Asignar la velocidad calculada y mover al personaje
		Velocity = velocity;

		// Usar MoveAndSlide para mover el personaje con la física
		MoveAndSlide();
		SelectAnimation();
	}
	
	public void SelectAnimation()
	{	if (!isAttack){
			if (Velocity.X == 0 )
			{
				_animatedSprite3D.Play("idle");
			} else if (Velocity.X < 0) {
				_animatedSprite3D.Play("swimming");
				_animatedSprite3D.FlipH = true;
			}
			 else if (Velocity.X > 0) {
				_animatedSprite3D.Play("swimming");
				_animatedSprite3D.FlipH = false;
			}
		}
		else
		{
			_animatedSprite3D.Play("charged_attack");
		}
		
	}
	
	public void OnAnimatedSprite3DAnimationFinished(){
		if(_animatedSprite3D.Animation == "charged_attack"){
			isAttack = false;
		}
		
	}
}
