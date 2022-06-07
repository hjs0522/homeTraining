using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEndController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.curSquatNum = 0;
            PlayerController.maxSquatNum = 5;
            PlayerController.playerStatus = PlayerController.PLAYERSTATUS.FINAL_SQUAT;
            PlayerController.squatText = GameManager.Instance.gameUIs[(int)GameManager.GAMEUI.FINAL_SQUAT].GetComponentsInChildren<Text>()[1];
            GameManager.Instance.gameUIs[((int)GameManager.GAMEUI.FINAL_SQUAT)].SetActive(true);
            Debug.Log("FINAL SQUAT_START");
        }
    }
}
