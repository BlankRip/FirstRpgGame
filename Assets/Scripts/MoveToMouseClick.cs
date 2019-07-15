using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToMouseClick : MonoBehaviour
{
    //Variables requied to raycast
    Ray rayFromCamera;
    RaycastHit triggered;
    [SerializeField] string LayerMaskName;

    // Variables required to move the player to the point where the user clicks
    Vector3 direction;
    float distance;
    [SerializeField] float speed;

    //To move player using nave-mesh
    [SerializeField] bool usingNavMesh;
    [SerializeField] NavMeshAgent agent;


    void Update()
    {
        rayFromCamera = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(usingNavMesh)    //if the game is using navMesh to move player
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(Camera.main.transform.position, rayFromCamera.direction, out triggered, Mathf.Infinity, LayerMask.GetMask(LayerMaskName)))
                {
                    agent.SetDestination(triggered.point);                 // setting destination point to the mouse click position
                }
            }
        }
        else if (!usingNavMesh)   // if the game does not want to use navMesh (maybe when i don't want the player to click in a diffent location and i don't want the computer to just navigate to that place insted move in that direction agains the obstacle indicating the player to navigate by Himself
        {
            distance = Vector3.Distance(transform.position, triggered.point);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(Camera.main.transform.position, rayFromCamera.direction, out triggered, Mathf.Infinity, LayerMask.GetMask(LayerMaskName)))
                {
                    direction = (triggered.point - transform.position).normalized;
                    transform.LookAt(new Vector3(triggered.point.x, transform.position.y, triggered.point.z));          // It will work well if the rotation on the x & z axis are locked on in the rigidbody
                    Debug.DrawRay(Camera.main.transform.position, rayFromCamera.direction * 100, Color.green);
                }
            }

            //Checking if the player is close to the destination
            if (distance > 1)
            {
                transform.position += direction * speed * Time.deltaTime;
            }
        }
    }
}
