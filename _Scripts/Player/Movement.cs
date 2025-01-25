using Godot;
using System;

public partial class Movement : CharacterBody3D
{
	public const float Speed = 5.0f; // Velocidad de movimiento
	public const float JumpVelocity = 10f; // Velocidad del salto
	public const float FloatVelocity = 2.0f; // Velocidad mientras flota
	
	private bool isJumping = false; // Verifica si el usuario está saltando

	public override void _PhysicsProcess(double delta)
	{
		// Obtener la velocidad actual del personaje
		Vector3 velocity = Velocity;

		 if (Input.IsActionPressed("ui_accept"))
		{
			velocity.Y = Mathf.Min(velocity.Y + FloatVelocity * (float)delta, JumpVelocity); // Subir mientras se mantiene presionado
		}
		
		if (Input.IsActionPressed("ui_down2") && !IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Movimiento en el plano horizontal
		Vector2 inputDir = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();

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
	}
}
