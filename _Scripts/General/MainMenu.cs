using Godot;
using System;

public partial class MainMenu : Control
{
	private Button _startButton;
	private Button _optionsButton;
	private Button _exitButton;

	public override void _Ready()
	{
		// Referencias a los nodos
		_startButton = GetNode<Button>("MarginContainer/HBoxContainer/VBoxContainer/Start_Button");
		_optionsButton = GetNode<Button>("MarginContainer/HBoxContainer/VBoxContainer/Options_button");
		_exitButton = GetNode<Button>("MarginContainer/HBoxContainer/VBoxContainer/Exit_button");
		
		// Conectar señales de los botones
		_optionsButton.Pressed += OnOptionsButtonPressed;
		_exitButton.Pressed += OnExitButtonPressed;
	}

	private void OnStartButtonPressed()
	{
		// Cambia a la escena principal del juego
		GD.Print("Iniciando el juego...");
		GetTree().ChangeSceneToFile("res://Prueba.tscn"); // Asegúrate de ajustar la ruta de la escena
	}

	private void OnOptionsButtonPressed()
	{
		// Menu de opciones
		GD.Print("Abriendo las opciones...");
		GetTree().ChangeSceneToFile("res://Scenes/Options_Menu.tscn"); 
	}


	private void OnExitButtonPressed()
	{
		// Salir del juego
		GD.Print("Saliendo del juego...");
		GetTree().Quit();
	}

	private void OnNivelButtonPressed(int nivel) {
		GameManager.Instancia.CargarNivel(nivel);
	}
}
