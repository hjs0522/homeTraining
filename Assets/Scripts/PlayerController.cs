using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_moveSpeed = 10.0f;
    private float x, z;
    void Start()
    {
        
    }

    void Update()
    {
        z = Input.GetAxis("Vertical") * m_moveSpeed * Time.deltaTime;
        x = Input.GetAxis("Horizontal") * m_moveSpeed * Time.deltaTime;
        transform.Translate(x, 0 ,z);
    }
}
