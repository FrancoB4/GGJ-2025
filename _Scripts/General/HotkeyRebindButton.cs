using Godot;
using System;

public partial class HotkeyRebindButton : Control
{
	private Button _button;
	private Label _label;
	
	[Export]
	public string Action_Name;
	
	public override void _Ready()
	{
		_label = GetNode<Label>("HBoxContainer/Label");
		_button = GetNode<Button>("HBoxContainer/Button");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
