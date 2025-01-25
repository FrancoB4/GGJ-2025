using Godot;
using System;

public partial class InterfazIngame : Control
{
    [Signal]
    public delegate void ActivarFiltroEventHandler();
    [Signal]
    public delegate void DesactivarFiltroEventHandler();
    [Signal]
    public delegate void ActivarFiltroGameOverSignalEventHandler();
    private ProgressBar progressBar;
    private ColorRect colorRect;
    private Label textoGameOver;
    private Button botonReintentar;
    bool filtroActivado = false;

    public override void _Ready()
    {
        progressBar = GetNode<ProgressBar>("ProgressBar");
        colorRect = GetNode<ColorRect>("ColorRect");
        textoGameOver = GetNode<Label>("TextoGameOver");
        botonReintentar = GetNode<Button>("BotonReintentar");
    }

    public void ActualizarValor(int value) {
        progressBar.OnOxigenoChanges(value);
        if (filtroActivado && value > 15) {
            DesactivarFiltroPocoOxigeno();
        }
        else if (!filtroActivado && value < 15) {
            ActivarFiltroPocoOxigeno();
        }
    }

    public double Valor() {
        return progressBar.Value;
    }

    private void ActivarFiltroPocoOxigeno() {
        EmitSignal(SignalName.ActivarFiltro);
    }

    private void DesactivarFiltroPocoOxigeno() {
        EmitSignal(SignalName.DesactivarFiltro);
    }

    private void ActivarFiltroGameOver() {
        EmitSignal(SignalName.ActivarFiltroGameOverSignal);
        progressBar.Visible = false;
        textoGameOver.Visible = true;
        botonReintentar.Visible = true;
    }

    private void RecargarEscena() {
        GetTree().ChangeSceneToFile("res://Escenas/Niveles/PantallaDeCarga.tscn");
    }
}
