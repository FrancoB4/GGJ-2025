using Godot;
using System;

public partial class NivelButton : Button
{
    [Signal]
    public delegate void ButtonPressedEventHandler();
    [Export]
    public int nivel;
	
    private void OnPressed() {
        EmitSignal(SignalName.ButtonPressed, nivel);
    }
}
