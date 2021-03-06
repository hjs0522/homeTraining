using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyFollow : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    private Transform player;

    public float maxRotation = 45.0f;
    public float rotationSpeed = 10.0f;

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        player = GameManager.Instance.playerObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        //enemyAgent.velocity = new Vector3(0, 0, 0);
        //return;

        if (GameManager.Instance.gameStatus == GameManager.GAMESTATUS.ONGOING)
        {
            Vector3 destination = new Vector3(player.position.x, player.position.y, player.position.z);
            enemyAgent.SetDestination(destination);

            //if (transform.rotation.x <= maxRotation)
            //{
            //    transform.rotation = Quaternion.Slerp(
            //        transform.rotation, 
            //        Quaternion.Euler(new Vector3(maxRotation, transform.rotation.y, transform.rotation.z)),
            //        Time.time*rotationSpeed
            //        );
            //}

            if ((player.position - transform.position).magnitude <= enemyAgent.stoppingDistance)
            {
                enemyAgent.velocity = new Vector3(0.0f, 0.0f, 0.0f);
                GameManager.Instance.GameFail();
            }
        }
        else
        {
            enemyAgent.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        }
    }
}
