using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementGaugeController : MonoBehaviour
{
    public enum STANDARDTYPE {PLAYER, ENEMY};
    public STANDARDTYPE thisType;
    public Slider slider;
    public Transform standard;
    public Image fill;
    public Color fillColor;

    private float sliderLvalue = 0.0f;
    private float sliderRvalue = 0.0f;
    private float SliderLvalue
    {
        get
        {
            return sliderLvalue; 
        }
        set
        {
            if (value > 0.0f)
            {
                sliderLvalue = 0.0f;
            }
            else
            {
                sliderLvalue = value;
            }
        }
    }

    private void Start()
    {
        if (thisType.Equals(STANDARDTYPE.PLAYER)) standard = GameManager.Instance.playerObj.transform;
        else if(thisType.Equals(STANDARDTYPE.ENEMY)) standard = GameManager.Instance.enemyObj.transform;
        else Debug.LogWarning("STANDARTYPE of GAUGE not assgined");
        fill.color = fillColor;
    }

    private void Update()
    {
        SliderLvalue = (GameManager.Instance.endTriggerPos.transform.position - standard.transform.position).magnitude;
        sliderRvalue = (GameManager.Instance.endTriggerPos.transform.position -
            GameManager.Instance.playerStartPos.transform.position).magnitude;
        slider.value = SliderLvalue / sliderRvalue;
        Debug.Log(thisType);
        Debug.Log(slider.value);
    }
}
