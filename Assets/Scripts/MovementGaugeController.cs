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

    public Image standardImage;
    public Transform imageStartPos;
    public Transform imageEndPos;

    //private float sliderLvalue;
    //private float sliderRvalue = 0.0f;
    private Vector3 onNormalVec;
    private Vector3 borderScale;

    //private float SliderLvalue
    //{
    //    get
    //    {
    //        return sliderLvalue; 
    //    }
    //    set
    //    {
    //        if (value > 0.0f)
    //        {
    //            sliderLvalue = 0.0f;
    //        }
    //        else
    //        {
    //            sliderLvalue = value;
    //        }
    //    }
    //}

    private void Start()
    {
        if (thisType.Equals(STANDARDTYPE.PLAYER)) standard = GameManager.Instance.playerObj.transform;
        else if(thisType.Equals(STANDARDTYPE.ENEMY)) standard = GameManager.Instance.enemyObj.transform;
        else Debug.LogWarning("STANDARTYPE of GAUGE not assgined");
        onNormalVec = GameManager.Instance.endTriggerPos.position - GameManager.Instance.playerStartPos.position;
        slider.value = 0.0f;
        slider.maxValue = 1.0f;
        borderScale = imageEndPos.position - imageStartPos.position;
        fill.color = fillColor;
    }

    private void Update()
    {
        Vector3 lvalueVec = Vector3.Project((standard.position - GameManager.Instance.playerStartPos.position), onNormalVec);
        float lvalueDot =  Vector3.Dot(lvalueVec, onNormalVec);
        if (lvalueDot <= 0.0f) slider.value = 0.0f;
        else slider.value = (lvalueVec.magnitude / onNormalVec.magnitude) * slider.maxValue;
        standardImage.transform.position = new Vector3(
            imageStartPos.position.x + borderScale.x * slider.value, 
            imageStartPos.position.y + borderScale.y * slider.value, 
            0.0f
            );
    }
}
