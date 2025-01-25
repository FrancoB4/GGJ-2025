using Godot;
using System;

public partial class FiltroPocoOxigeno : ColorRect
{
    private float effectStrength = 0f;
    private Vector4 centerColor = new Vector4();
    private bool gameOver = false;
    private bool terminar = false;
	public override void _Ready() {
        GD.Print((Material as ShaderMaterial).GetShaderParameter("center_color"));
    }

    public override void _Process(double delta) {
        if (!terminar) {
            (Material as ShaderMaterial).SetShaderParameter("effect_strength", effectStrength);
            if (gameOver) {
                (Material as ShaderMaterial).SetShaderParameter("center_color", centerColor);
                if (centerColor == new Vector4(0, 0, 0, 1)) {
                    terminar = true;
                }
            }
        }
    }

    private void Activar() {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "effectStrength", 1, 2)
        .SetTrans(Tween.TransitionType.Linear);
    }

    private void Desactivar() {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "effectStrength", 0, 2)
        .SetTrans(Tween.TransitionType.Linear);
    }

    private void FiltroGameOver() {
        gameOver = true;
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "centerColor", new Vector4(0, 0, 0, 1), 2)
        .SetTrans(Tween.TransitionType.Linear);
    }

    private void RecargarEscena() {
        gameOver = false;
        terminar = false;
        centerColor = Vector4.Zero;
        (Material as ShaderMaterial).SetShaderParameter("center_color", centerColor);
        effectStrength = 0f;
    }
}
