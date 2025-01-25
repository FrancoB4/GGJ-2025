using Godot;
using System;

public partial class Lever : Node3D
{
	private bool isPlayerNearby = false; // Indica si el jugador está dentro del área
	private Label interactLabel; // Referencia al mensaje de interacción
	private bool isLeverActive = false; // Estado de la palanca
	private Label Actived;
	private Label Desactived;

	public override void _Ready()
	{
		// Obtén el nodo del Label que mostrará el mensaje
		interactLabel = GetNode<Label>("Message");
		
		Actived = GetNode<Label>("PalancaActivada");
		Desactived = GetNode<Label>("PalancaDesactivada");
		
		interactLabel.Visible = false; // Oculta el mensaje inicialmente
	}

	private void _on_Area3D_body_entered(Node3D body)
	{
		if (body is Movement) // Verifica si el cuerpo que entra es el jugador
		{
			isPlayerNearby = true;
			interactLabel.Visible = true; // Muestra el mensaje
		}
	}

	private void _on_Area3D_body_exited(Node3D body)
	{
		if (body is Movement) // Verifica si el cuerpo que sale es el jugador
		{
			isPlayerNearby = false;
			interactLabel.Visible = false; // Oculta el mensaje
		}
	}

	public override void _Process(double delta)
	{
		// Verifica si el jugador está cerca y presionó la tecla de interacción
		if (isPlayerNearby && Input.IsActionJustPressed("interactive"))
		{
			ToggleLever();
		}
	}

	private void ToggleLever()
	{
		// Alterna el estado de la palanca
		isLeverActive = !isLeverActive;

		if (isLeverActive)
		{
			GD.Print("Palanca activada");
		}
		else
		{
			GD.Print("Palanca desactivada");
		}
	}
}
