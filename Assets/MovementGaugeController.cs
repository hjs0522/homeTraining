using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementGaugeController : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //for initialize
    public void SetGaugeZero()
    {
        slider.value = 0;
        fill.color = gradient.Evaluate(0.0f);
    }
    public void SetMovementGauge(float movement)
    {
        slider.value = movement;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
