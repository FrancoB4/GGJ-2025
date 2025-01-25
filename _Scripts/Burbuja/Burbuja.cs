using Godot;
using System;

public partial class Burbuja : Node3D
{
    [Export]
    public float speed = 2;
    private int oxigenoTotal;
    private bool onCollisionPlayer = false;
    private GpuParticles3D gpuParticles3D;
    private Godot.Timer timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        RandomNumberGenerator rand = new RandomNumberGenerator();
        rand.Randomize();
        oxigenoTotal = rand.RandiRange(15, 30);

        gpuParticles3D = GetNode<GpuParticles3D>("GPUParticles3D");
        gpuParticles3D.Amount = oxigenoTotal;

        timer = GetNode<Timer>("Timer");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    private void OnBodyEntered(Node body) {
        if (body.Name == "Player" && !onCollisionPlayer) {
            onCollisionPlayer = true;
            timer.Start();
        }
    }

    private void OnBodyExited(Node body) {
        if (body.Name == "Player" && onCollisionPlayer) {
            onCollisionPlayer = false;
            timer.Stop();
        }
    }

    private void OnOxigenoTimerTimeout() {
        GameManager.Instancia.AgregarOxigeno(1);
        oxigenoTotal--;
        if (oxigenoTotal == 0) {
            QueueFree();
        }
        gpuParticles3D.Amount -= 1;
    }
}
