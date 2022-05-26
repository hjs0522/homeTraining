using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.playerArrivalEnd = true;
            GameManager.Instance.gameUIs[((int)GameManager.GAMEUI.SQUAT)].SetActive(true);
            Debug.Log(other.gameObject.name);
            Debug.Log(gameObject.name);
            Debug.Log(other.transform.position);
            Debug.Log(transform.position);
        }
    }
}
