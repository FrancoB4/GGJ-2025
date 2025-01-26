using Godot;
using System;

public partial class OptionsMenu : Control
{
	private Button _closeButton;
	
	public override void _Ready()
	{
		// Referencias a los nodos
		_closeButton = GetNode<Button>("MarginContainer/VBoxContainer/Close_button");
		
		// Conectar señales de los botones
		_closeButton.Pressed += OnCloseButtonPressed;
	}
	
	private void OnCloseButtonPressed()
	{
		// Salir del juego
		GD.Print("Cerrando las opciones...");
		GetTree().ChangeSceneToFile("res://Escenas/Niveles/Main_Menu.tscn");
	}
}
