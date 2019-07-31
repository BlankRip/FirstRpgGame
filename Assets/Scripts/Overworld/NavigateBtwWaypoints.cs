using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateBtwWaypoints : MonoBehaviour
{
    [SerializeField] GameObject player; 
    [SerializeField] GameObject[] waypoints;
    [SerializeField] float followRange;              //the distence at which  the objet should start chasing the player
    [SerializeField] float speed;                    // speed at whih the enmey moves
    int index = 0;                                   // which waypoint it is at or moving to right now
    float distance;                                  // distance between enemy and waypoint
    [SerializeField] float switchWaypointAtDistance; // add to index when the distance between waypoints is less than this
    float distanceBtwPlayer;                         // distance between enemy and player
    Vector3 direction;                               // diretion to move in
    bool inverse;                                    // swith teh movement diretions
    bool chasePlayer;                                // to chase player or not
     
    // Start is called before the first frame update
    void Start()
    {
        direction = (waypoints[index].transform.position - transform.position).normalized;
    }

    
    void Update()
    {
        //Setting to chase player or resetting enemy position if player gets away
        distanceBtwPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceBtwPlayer < followRange)
        {
            chasePlayer = true;
        }
        else if(distanceBtwPlayer > followRange * 2 && chasePlayer)
        {
            chasePlayer = false;
            index = 0;
            direction = (waypoints[index].transform.position - transform.position).normalized;
            transform.position = waypoints[index].transform.position;
        }

        // The movement between way points and set diretion to player if chasing
        if (!chasePlayer)
        {
            distance = Vector3.Distance(transform.position, waypoints[index].transform.position);
            if (distance < switchWaypointAtDistance)
            {
                if (!inverse)
                {
                    if (index >= waypoints.Length - 2)
                    {
                        inverse = true;
                    }
                    index++;
                }
                else
                {
                    if (index <= 1)
                    {
                        inverse = false;
                    }
                    index--;
                }
                direction = (waypoints[index].transform.position - transform.position).normalized;
            }
        }
        else if(chasePlayer)
        {
            direction = (player.transform.position - transform.position).normalized;
        }

        transform.position += direction * speed * Time.deltaTime;                                      // moving to the current target
    }
}
