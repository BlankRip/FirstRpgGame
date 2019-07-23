﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattler : MonoBehaviour
{
    BattleManager manager;

    private void Start()
    {
        manager = FindObjectOfType<BattleManager>();
        print("settings");
    }

    public void Attack()
    {
        print("<color=red> NOW ATTACKING </color>");
        manager.enemyTurn = true;
        manager.playerTurn = false;
    }
    public void SpecialAttack()
    {
        print("<color=cyan> USING SPECIAL ATTACK </color>");
        manager.enemyTurn = true;
        manager.playerTurn = false;
    }
    public void Defence()
    {
        print("<color=green> NOW DEFENDING </color>");
        manager.enemyTurn = true;
        manager.playerTurn = false;
    }

    void Update()
    {
        
    }
}
