using Godot;
using System;

public partial class Burbuja : Node3D
{
    [Export]
    public float speed = 2;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
        Position += new Vector3(0, speed * (float)delta, 0);
	}

    private void OnBodyEntered(Node body) {
        if (body.Name == "Player") {
            GameManager.Instancia.AgregarOxigeno(15);
        }
        GD.Print("Hola");
        QueueFree();
    }
}
