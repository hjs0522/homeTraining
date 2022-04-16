using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEndController : MonoBehaviour
{
    public bool m_isGameEnd = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player") && !m_isGameEnd)
        {
            m_isGameEnd = true;
            GameManager.Instance.StopGame();
        }
    }
}
