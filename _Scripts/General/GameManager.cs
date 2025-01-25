using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Timers;

public partial class GameManager : Node
{
	public static GameManager Instancia { get; private set; }
    private InterfazIngame interfazIngame;
	private int oxigeno;
	private bool pocoOxigeno = false;

	private GameManager() { }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instancia = this;
		oxigeno = 60;        
		Godot.Timer timer = GetChild<Godot.Timer>(0);
		timer.Start();

        interfazIngame = GetNode<InterfazIngame>("InterfazIngame");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void GameOver() {

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
			PocoOxigenoFilterOff();
            pocoOxigeno = false;
		}
        interfazIngame.ActualizarValor(oxigeno);
		GD.Print(oxigeno);
	}

	public void QuitarOxigeno(int cant) {
		oxigeno -= cant;
		if (oxigeno < 15 && !pocoOxigeno) {
			PocoOxigenoFilterOn();
			pocoOxigeno = true;
		}
		else if (oxigeno <= 0) {
			GameOver();
		}
        interfazIngame.ActualizarValor(oxigeno);
		GD.Print(oxigeno);
	}

	private void PocoOxigenoFilterOn() {
		
	}

	private void PocoOxigenoFilterOff() {
		
	}
}
