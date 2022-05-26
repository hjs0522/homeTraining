using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float m_moveSpeed = 10.0f;
    public int maxSquatNum;
    private float x, z;
    private int curSquatNum;
    private Text squatText;

    private void Start()
    {
        curSquatNum = 0;
        squatText = GameManager.Instance.gameUIs[((int)GameManager.GAMEUI.SQUAT)].GetComponentsInChildren<Text>()[1];
    }

    void Update()
    {
        if(GameManager.Instance.gameStatus == GameManager.GAMESTATUS.ONGOING)
        {
            if (GameManager.Instance.playerInputAccept)
            {
                if (GameManager.Instance.playerArrivalEnd)
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        curSquatNum++;
                        squatText.text = curSquatNum.ToString();
                        if (curSquatNum >= maxSquatNum)
                        {
                            GameManager.Instance.GameClear();
                        }
                    }
                }
                else
                {
                    z = Input.GetAxis("Vertical") * m_moveSpeed * Time.deltaTime;
                    x = Input.GetAxis("Horizontal") * m_moveSpeed * Time.deltaTime;
                    transform.Translate(x, 0, z);
                }
            }
        }
    }
}
