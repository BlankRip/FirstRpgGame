using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAnimationManager : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;
    [SerializeField] PlayerBattler player;
    [SerializeField] BattleManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.enemyTurn)
        {
            //playerAnimator.SetBool("Attacking", false);
        }
    }
}
