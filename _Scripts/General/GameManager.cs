using Godot;
using System;
using System.Linq;

public partial class GameManager : Node
{
	[Signal]
	public delegate void GameOverSignalEventHandler();
	public static GameManager Instancia { get; private set; }
	[Export]
	public int nivel = 0;
	private InterfazIngame interfazIngame;
	private int oxigeno;
	private bool pocoOxigeno = false;
	private ColorRect filtroPocoOxigeno;

	private GameManager() { }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instancia = this;
		oxigeno = 60;
		if (nivel != 0) {
			Timer timer = GetNode<Timer>("OxigenTimer");
			timer.Start();
			interfazIngame = GetNode<InterfazIngame>("InterfazIngame");
		}
		RequestReady();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	public void GameOver() {
		EmitSignal(SignalName.GameOverSignal);
	}

	public void OnOxigenTimerTimeout() {
		QuitarOxigeno(1);
	}

	public void AgregarOxigeno(int cant) {
		if (oxigeno + cant <= 100) {
			oxigeno += cant;
		}
		else {
			oxigeno = 100;
		}
		if (oxigeno >= 15) {
			pocoOxigeno = false;
		}
		interfazIngame.ActualizarValor(oxigeno);
	}

	public void QuitarOxigeno(int cant) {
		oxigeno -= cant;
		if (oxigeno < 15 && !pocoOxigeno) {
			pocoOxigeno = true;
		}
		else if (oxigeno <= 0) {
			GetNode<Timer>("OxigenTimer").Stop();
			GameOver();
		}
		interfazIngame.ActualizarValor(oxigeno);
	}

	public void Reiniciar() {
		oxigeno = 60;
		pocoOxigeno = false;
	}
	public void CargarNivel(int nivel) {
		Instancia.nivel = nivel;
		GetTree().ChangeSceneToFile("res://Escenas/Niveles/PantallaDeCarga.tscn");
	}
}
