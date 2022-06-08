using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideSquatScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.curSquatNum = 0;
            PlayerController.maxSquatNum = 7;
            PlayerController.playerStatus = PlayerController.PLAYERSTATUS.SIDE_SQUAT;
            PlayerController.squatText = GameManager.Instance.gameUIs[(int)GameManager.GAMEUI.SIDE_SQUAT].GetComponentsInChildren<Text>()[1];
            GameManager.Instance.gameUIs[((int)GameManager.GAMEUI.SIDE_SQUAT)].SetActive(true);
            Debug.Log("SIDE SQUAT START");
        }
    }
}
