using Godot;
using Microsoft.VisualBasic;
using System;

public partial class ProgressBar : Godot.ProgressBar
{
	public void OnOxigenoChanges(int value) {
        Tween tween = GetTree().CreateTween();
        tween.TweenProperty(this, "value", value, 1).SetTrans(Tween.TransitionType.Linear);
    }
}
