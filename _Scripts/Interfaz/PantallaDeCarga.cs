using Godot;
using System;

public partial class PantallaDeCarga : Control
{
    public override void _Ready()
    {
        Timer timer = GetNode<Timer>("Timer");
        timer.Start();
    }
    private void OnTimerOut() {
        string nivel = "nivel_" + GameManager.Instancia.nivel + ".tscn";
        GameManager.Instancia.Reiniciar();
        GetTree().ChangeSceneToFile("res://Escenas/Niveles/" + nivel);
    }
}
