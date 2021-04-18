using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    NavMeshAgent movement;
    public Transform player;
    public Transform spawn;

    public float distFromSpawn = 20;
    public float distFromEnemy = 10;

    enum AI {idle, pursuing};
    AI trackingState = AI.idle;

    // Start is called before the first frame update
    void Start()
    {

        //ensures the correct navmeshagent is in use
        movement = GetComponent<NavMeshAgent>();

        movement.SetDestination(spawn.position);
    }

    // Update is called once per frame
    void Update()
    {
        switch (trackingState)
        {
            case AI.idle:
            {
                movement.SetDestination(spawn.position); ;
                
                if(Vector3.Distance(player.position, this.transform.position) < distFromEnemy && Vector3.Distance(player.position, spawn.position) < distFromSpawn)
                {
                    trackingState = AI.pursuing;
                }

                break;
            }

            case AI.pursuing:
            {
                movement.SetDestination(player.position);

                if (Vector3.Distance(player.position, this.transform.position) >= distFromEnemy || Vector3.Distance(player.position, spawn.position) >= distFromSpawn)
                {
                    trackingState = AI.idle;
                }

                break;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(4);
        }
    }
}
