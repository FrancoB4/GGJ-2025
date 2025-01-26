using Godot;
using System;

public partial class MenuPrincipalNiveles : TabContainer
{
	private void ToggleHabilitar() {
        this.Visible = !this.Visible;
    }
}
