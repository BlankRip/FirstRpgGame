using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattler : MonoBehaviour
{
    BattleManager manager;
    public int enemyHealth;

    private void Start()
    {
        manager = FindObjectOfType<BattleManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.enemyTurn == true)
        {
            print("<color=pink> my trun</color>");
            manager.playerTurn = true;
            manager.enemyTurn = false;
        }
    }
}
