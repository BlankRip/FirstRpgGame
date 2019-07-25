using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationTriggersWorld : MonoBehaviour
{
    [SerializeField] Animator unityChanMoveAnimations;
    [SerializeField] NavMeshAgent playerNavAgent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerNavAgent.remainingDistance > playerNavAgent.stoppingDistance)
            unityChanMoveAnimations.SetBool("Running", true);
        else
            unityChanMoveAnimations.SetBool("Running", false);
    }
}
