using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab, enemyPrefab, endTriggerPrefab;
    public GameObject playerObj, enemyObj, endTriggerObj;
    public Transform playerStartPos, enemyStartPos, endTriggerPos;
    private static GameManager instance = null;
    public bool playerArrivalEnd { get; set; }
    public bool gameEnded { get; set; }
    public bool playerInputAccept { get; set; }

    private bool stopGameOperated;

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

        StartGame();
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

    private void Update()
    {
        if (gameEnded && !stopGameOperated) StopGame();
    }

    public void StartGame()
    {
        playerObj = Instantiate(playerPrefab, playerStartPos.transform.position, Quaternion.identity);
        enemyObj = Instantiate(enemyPrefab, enemyStartPos.transform.position, Quaternion.identity);
        endTriggerObj = Instantiate(endTriggerPrefab, endTriggerPos.transform.position, Quaternion.identity);
        playerArrivalEnd = false;
        playerInputAccept = true;
        gameEnded = false;
        stopGameOperated = false;
    }

    public void StopGame()
    {
        stopGameOperated = true;
        playerInputAccept = false;
        Debug.Log("Game Ended!");
    }
}
