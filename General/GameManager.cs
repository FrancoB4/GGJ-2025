using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Timers;

public partial class GameManager : Node
{
    private static GameManager gameManager;
    private int oxigeno = 60;
    private bool pocoOxigeno = false;

    private GameManager() { }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public static GameManager Instancia {
        get {
            if (gameManager == null) {
                gameManager = new GameManager();
            }
            return gameManager;
        }
    }

    public void GameOver() {

    }

    public void OnOxigenTimerTimeout() {
        QuitarOxigeno(1);
    }

    public void AgregarOxigeno(int cant) {
        oxigeno += cant;
        if (oxigeno >= 15) {
            PocoOxigenoFilterOff();
        }
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
    }

    private void PocoOxigenoFilterOn() {
        
    }

    private void PocoOxigenoFilterOff() {
        
    }
}
