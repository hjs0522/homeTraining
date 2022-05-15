using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGaugeController : MonoBehaviour
{
    public Slider slider;
    public Transform endPoint, startPoint;
    public Transform standard;
    public Image fill;
    public Color fillColor;

    private Slider playerSlider;
    private Vector3 endPos, startPos;

    private void Start()
    {
        playerSlider = FindObjectOfType<MovementGaugeController>().slider;
        endPos = endPoint.transform.position;
        startPos = startPoint.transform.position;
        fill.color = fillColor;
    }

    private void Update()
    {
        slider.value = playerSlider.value - (standard.transform.position.magnitude - startPos.magnitude)
            / (endPos.magnitude - startPos.magnitude);
    }
}
