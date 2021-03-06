using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab, enemyPrefab, endTriggerPrefab;
    public GameObject playerObj, enemyObj, endTriggerObj;
    public GameObject clearObj;
    public Transform playerStartPos, enemyStartPos, endTriggerPos;
    private static GameManager instance = null;
    public List<Transform> playerMorphs;
    private Transform[] playerTransforms;
    public bool playerArrivalEnd { get; set; }

    public bool playerInputAccept { get; set; }

    public enum GAMESTATUS {ONGOING, CLEAR, FAIL};

    public GAMESTATUS gameStatus;

    public enum GAMEUI { CLEAR, FAIL, JUMP_SQUAT, SIDE_SQUAT,  FINAL_SQUAT, QUICK_FEAT, WIDE_QUICK_FEAT };

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
        playerObj = Instantiate(playerPrefab, playerStartPos.transform.position, playerStartPos.rotation);
        enemyObj = Instantiate(enemyPrefab, enemyStartPos.transform.position, enemyStartPos.rotation);
        endTriggerObj = Instantiate(endTriggerPrefab, endTriggerPos.transform.position, endTriggerPos.rotation);
        PlayerController.playerStatus = PlayerController.PLAYERSTATUS.WALK;
        playerMorphs = new List<Transform>();
        playerTransforms = playerObj.GetComponentsInChildren<Transform>();
        for(int i = 0; i< playerTransforms.Length; i++)
        {
            if (playerTransforms[i].gameObject.tag.CompareTo("PlayerMorph") == 0)
            {
                playerMorphs.Add(playerTransforms[i]);
            }
        }
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
            clearObj.SetActive(false);
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
