using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuickfeatObstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.curSquatNum = 0;
            PlayerController.maxSquatNum = 10;
            PlayerController.playerStatus = PlayerController.PLAYERSTATUS.QUICK_FEAT;
            GameManager.Instance.gameUIs[((int)GameManager.GAMEUI.QUICK_FEAT)].SetActive(true);
        }
    }
}
