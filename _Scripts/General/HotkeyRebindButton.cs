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
		set_process_unhandled_key_input(false);
		set_action_name();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public override void set_action_name()
	{
		_label.text = "Unassigned";
		
		switch Action_Name{
			"move_left": label.text = "Move Left";
			"move_right": label.text = "Move Right";
			"move_approach": label.text = "Move Approach";
			"move_away": label.text = "Move Away";
			"move_up": label.text = "Up";
			"move_down": label.text = "Down";
			"attack": label.text = "Attack";
			"interactive": label.text = "Interact"
			"sonar": label.text = "Sonar";
			"accept": label.text = "Accept"
			"back": label.text = "Back"
		}
			
	}
}
