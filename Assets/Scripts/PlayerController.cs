using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float m_moveSpeed = 10.0f;
    public static int maxSquatNum;
    public static int curSquatNum;
    public static Text squatText;

    public enum PLAYERSTATUS { WALK, SQUAT, JUMP_SQUAT, SIDE_SQUAT, FINAL_SQUAT };
    public static PLAYERSTATUS playerStatus;

    private void Start()
    {
        curSquatNum = 0;
    }

    void Update()
    {
        if(GameManager.Instance.gameStatus == GameManager.GAMESTATUS.ONGOING)
        {
            if (GameManager.Instance.playerInputAccept)
            {
                if (playerStatus == PLAYERSTATUS.FINAL_SQUAT)
                {
                    squatText.text = curSquatNum.ToString();
                    if (curSquatNum >= maxSquatNum) GameManager.Instance.GameClear();
                }

                else if (playerStatus == PLAYERSTATUS.SIDE_SQUAT ||
                         playerStatus == PLAYERSTATUS.JUMP_SQUAT)
                {
                    squatText.text = curSquatNum.ToString();
                    if (curSquatNum >= maxSquatNum)
                    {
                        playerStatus = PLAYERSTATUS.WALK;
                        Debug.Log("JUMP SQUAT CLEAR");
                        GameManager.Instance.ClearAllUI();
                    }
                }
            }
        }
    }
}
