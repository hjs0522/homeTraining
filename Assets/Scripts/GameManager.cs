using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    void Awake()
    {
        if (null == instance)
        {
            instance = this;

            // 다른 씬으로 옮겨갈 때 없어지는 것 방지
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                Debug.LogWarning("GameManager is null!");
                return null;
            }
            return instance;
        }
    }

    public void StopGame()
    {
        Debug.Log("Game Ended!");
    }
}
