using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StairScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.curSquatNum = 0;
            PlayerController.maxSquatNum = 4;
            PlayerController.playerStatus = PlayerController.PLAYERSTATUS.JUMP_SQUAT;
            PlayerController.squatText = GameManager.Instance.gameUIs[(int)GameManager.GAMEUI.JUMP_SQUAT].GetComponentsInChildren<Text>()[1];
            GameManager.Instance.gameUIs[((int)GameManager.GAMEUI.JUMP_SQUAT)].SetActive(true);
            Debug.Log("JUMP SQUAT START");
        }
    }
}
