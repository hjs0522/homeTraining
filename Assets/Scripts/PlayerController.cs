using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_moveSpeed = 10.0f;
    private float x, z;
    private int arrivalSquat;

    private void Start()
    {
        arrivalSquat = 0;
    }

    void Update()
    {
        if (GameManager.Instance.playerInputAccept)
        {
            z = Input.GetAxis("Vertical") * m_moveSpeed * Time.deltaTime;
            x = Input.GetAxis("Horizontal") * m_moveSpeed * Time.deltaTime;
            transform.Translate(x, 0, z);
        }

        if (GameManager.Instance.playerArrivalEnd)
        {
            if (Input.GetButtonDown("Jump"))
            {
                arrivalSquat++;
                if(arrivalSquat >= 50)
                {
                    GameManager.Instance.gameEnded = true;
                }
            }
        }
    }
}
