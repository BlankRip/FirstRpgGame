using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//This is for looping between 2 points and chasing player if in range
public class EnemyLoopMovement_NaveMesh : MonoBehaviour
{
    // Required variabls 
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform startPoint;                      //First Point where object wants to loop between (could be the object starts)
    [SerializeField] Transform destinationPoint;                //Second Point where object wants to loop between
    [SerializeField] Transform player;                          // Player's position
    [SerializeField] float chasePlayerDistance;                 // How close the object should be to the player to make it chase the player
    [SerializeField] bool usePlayerChase;                       // Enables the object to chase player if the coder requires it to
    bool changeTarget = false;
    bool chasePlayer = false;



    void Update()
    {
        // Checking distances between loop points and player and choosing the target to move towards
        if (Vector3.Distance(player.transform.position, transform.position) > chasePlayerDistance && chasePlayer)
        {
            chasePlayer = false;
            changeTarget = true;
        }

        if(Vector3.Distance(player.transform.position, transform.position) < chasePlayerDistance && usePlayerChase)
        {
            chasePlayer = true;
        }
        else if(Vector3.Distance(destinationPoint.position, transform.position) < 0.3f)
        {
            changeTarget = true;
        }
        else if(Vector3.Distance(startPoint.position, transform.position) < 0.3f)
        {
            changeTarget = false;
        }


        // Setting the target
        if(chasePlayer)
            agent.SetDestination(player.position);
        else if(!changeTarget)
            agent.SetDestination(destinationPoint.position);
        else if(changeTarget)
        {
            agent.SetDestination(startPoint.position);
        }
    }
}
