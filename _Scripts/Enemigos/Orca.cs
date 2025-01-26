using Godot;
using System;

public partial class Orca : Node3D
{
	[Export]
	public float speed;
	[Export]
	public int daño;
	[Export]
	public CharacterBody3D player;
	private Vector3 target;
	private Timer cooldownAtaque;
	private bool enCooldownAtaque = false;
	private bool causoDaño = false;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		target = Position;
		cooldownAtaque = GetNode<Timer>("CooldownAtaque");
	}

	public override void _Process(double delta)
	{
		if (Position.X > player.Position.X) {
			GetNode<AnimatedSprite3D>("AnimatedSprite3D").FlipH = true;
		}
		else {
			GetNode<AnimatedSprite3D>("AnimatedSprite3D").FlipH = false;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (!enCooldownAtaque) {
			if (Position.DistanceTo(player.Position) < 15) {
				target = player.Position;
				if (Position.DistanceTo(player.Position) <= 4) {
					Atacar(player.Position, delta);
				}
			}

			if (Position.DistanceTo(target) > 4) {
				Acercarse(target, delta);
			}
		}
	}

	private void Acercarse(Vector3 target, double delta) {
		Position += Position.DirectionTo(target) * speed * (float) delta;
	}

	private void Atacar(Vector3 target, double delta) {
		Position += Position.DirectionTo(target) * speed * 3 * (float) delta;
	}

	private void OnCooldownAtaqueTimeout() {
		enCooldownAtaque = false;
		causoDaño = false;
		cooldownAtaque.Stop();
	}

	private void OnBodyEntered(Node body) {
		if (body.Name == "Player" && !causoDaño) {
			GameManager.Instancia.QuitarOxigeno(daño);
			causoDaño = true;
			enCooldownAtaque = true;
			cooldownAtaque.Start();
		}
	}
}
