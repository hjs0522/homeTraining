using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CliffScript : MonoBehaviour
{
    public enum CLIFFDIR {LEFT, RIGHT}
    public CLIFFDIR cliffdir;

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController.curSquatNum = 0;
            PlayerController.maxSquatNum = 5;
            PlayerController.playerStatus = PlayerController.PLAYERSTATUS.SIDE_SQUAT;
        }
    }
}
