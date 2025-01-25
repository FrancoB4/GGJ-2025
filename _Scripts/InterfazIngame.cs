using Godot;
using System;

public partial class InterfazIngame : Control
{
    private ProgressBar progressBar;

    public override void _Ready()
    {
        progressBar = GetNode<ProgressBar>("ProgressBar");
    }

    public void ActualizarValor(int value) {
        progressBar.OnOxigenoChanges(value);
    }

    public double Valor() {
        return progressBar.Value;
    }
}
