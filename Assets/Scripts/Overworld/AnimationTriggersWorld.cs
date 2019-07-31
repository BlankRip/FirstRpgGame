using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationTriggersWorld : MonoBehaviour
{
    [SerializeField] Animator unityChanMoveAnimations;
    [SerializeField] NavMeshAgent playerNavAgent;

    void Update()
    {
        if (playerNavAgent.remainingDistance > playerNavAgent.stoppingDistance)              //Turn to running state when the player is moving to his destination 
            unityChanMoveAnimations.SetBool("Running", true);
        else
            unityChanMoveAnimations.SetBool("Running", false);                               //Changing back to the idle animation state when not moving i.e at destination
    }
}
