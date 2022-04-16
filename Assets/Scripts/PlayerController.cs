using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_moveSpeed = 10.0f;
    public float m_curMovement;
    private float x, z;

    public MovementGaugeController m_movementGaugeCtlr;

    private void Start()
    {
        m_curMovement = 0.0f;
        m_movementGaugeCtlr.SetGaugeZero();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            PlusMovement(10.0f);
        }
        z = Input.GetAxis("Vertical") * m_moveSpeed * Time.deltaTime;
        x = Input.GetAxis("Horizontal") * m_moveSpeed * Time.deltaTime;
        transform.Translate(x, 0 ,z);
    }

    void PlusMovement(float movement)
    {
        m_curMovement += movement;
        m_movementGaugeCtlr.SetMovementGauge(m_curMovement);
    }
}
