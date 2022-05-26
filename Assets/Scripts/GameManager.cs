using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab, enemyPrefab, endTriggerPrefab;
    public GameObject playerObj, enemyObj, endTriggerObj;
    public Transform playerStartPos, enemyStartPos, endTriggerPos;
    private static GameManager instance = null;
    public bool playerArrivalEnd { get; set; }

    public bool playerInputAccept { get; set; }

    public enum GAMESTATUS {ONGOING, CLEAR, FAIL};

    public GAMESTATUS gameStatus;

    public enum GAMEUI { SQUAT, CLEAR, FAIL };

    public GameObject[] gameUIs;
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

    public void StartGame()
    {
        playerObj = Instantiate(playerPrefab, playerStartPos.transform.position, Quaternion.identity);
        enemyObj = Instantiate(enemyPrefab, enemyStartPos.transform.position, Quaternion.identity);
        endTriggerObj = Instantiate(endTriggerPrefab, endTriggerPos.transform.position, Quaternion.identity);
        playerArrivalEnd = false;
        playerInputAccept = true;
        gameStatus = GAMESTATUS.ONGOING;
        ClearAllUI();
    }

    public void GameClear()
    {
        if (gameStatus == GAMESTATUS.ONGOING)
        {
            gameStatus = GAMESTATUS.CLEAR;
            playerInputAccept = false;
            Debug.Log("Game Clear!");
            ClearAllUI();
            gameUIs[((int)GAMEUI.CLEAR)].SetActive(true);
        }
    }
    public void GameFail()
    {
        if(gameStatus == GAMESTATUS.ONGOING)
        {
            gameStatus = GAMESTATUS.FAIL;
            playerInputAccept = false;
            Debug.Log("Game Over!");
            ClearAllUI();
            gameUIs[((int)GAMEUI.FAIL)].SetActive(true);
        }
    }

    public void ClearAllUI()
    {
        for(short i = 0; i < gameUIs.Length; i++)
            gameUIs[i].SetActive(false);
    }
}
