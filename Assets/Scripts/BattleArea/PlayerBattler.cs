using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattler : MonoBehaviour
{
    //Basics
    BattleManager manager;
    AudioManager manageSound;
    [SerializeField] Animator animate;

    //Stuff related to attacking
    [SerializeField] float attackDamageNormal;                      // Amount of damage player will do to enemy when using normal attack
    [SerializeField] int specialDamageNormal;                       // Amount of damage player will do to enemy when using special attack
    float attackDamageCritical;                                     // Amount of damage done when the normal attack is a critical hit
    float specialDamageCritical;                                    // Amount of damage done when the special attack is a critical hit
    int hitChance;                                                  // A random number generated to decide if the attack should be a critical hit

    private void Start()
    {
        manager = FindObjectOfType<BattleManager>();
        manageSound = FindObjectOfType<AudioManager>();
        attackDamageCritical = attackDamageNormal * 1.5f;                  // Setting the value of the critical damage for normal attack
        specialDamageCritical = specialDamageNormal * 1.5f;                // Setting the value of the critical damage for special attack
        print("settings");
        //var clip = animate.GetCurrentAnimatorClipInfo(0).Length;
    }


    //Attack Function
    public void Attack()
    {
        manageSound.AttackSound();                                //Play attack soundeffect
        animate.SetTrigger("Attacking");                          //Attack animation

        hitChance = Random.Range(0, 10);
        if (hitChance < 7)
        {
            manager.currentBattler.enemyHealth -= (int)attackDamageNormal;
            manager.enemyHealthBar.value = manager.currentBattler.enemyHealth;
            manager.DidEnemyDie();
            print("<color=red> NOW ATTACKING </color>");
        }
        else if(hitChance >= 7)
        {
            manager.currentBattler.enemyHealth -= (int)attackDamageCritical;
            manager.enemyHealthBar.value = manager.currentBattler.enemyHealth;
            manager.DidEnemyDie();
            print("<color=red> NOW ATTACKING Crit </color>");
        }
        
        //Switching turns
        manager.enemyTurn = true;
        manager.playerTurn = false;
    }


    //Special Attack function
    public void SpecialAttack()
    {
        manageSound.SpecialSound();                                //Play special soundeffect
        animate.SetTrigger("Special");                             //Special animation
        hitChance = Random.Range(0, 10);
        if (hitChance <= 8 && hitChance >= 2)
        {
            manager.currentBattler.enemyHealth -= (int)specialDamageNormal;
            manager.enemyHealthBar.value = manager.currentBattler.enemyHealth;
            manager.DidEnemyDie();
            print("<color=cyan> USING SPECIAL ATTACK </color>");
        }
        else if (hitChance < 2 || hitChance == 9)
        {
            manager.currentBattler.enemyHealth -= (int)specialDamageCritical;
            manager.enemyHealthBar.value = manager.currentBattler.enemyHealth;
            manager.DidEnemyDie();
            print("<color=cyan> USING SPECIAL ATTACK Crit </color>");
        }

        //Switching turns
        manager.enemyTurn = true;
        manager.playerTurn = false;
    }


    //Defence spell function
    public void Defence()
    {
        manageSound.DefenceSound();                                //Play defence spell soundeffect
        animate.SetTrigger("Defending");                           //Defence animation
        manager.playerProtectionOn = true;
        manager.turnesProtected = 2;
        print("<color=green> NOW DEFENDING </color>");

        //Switching turns
        manager.enemyTurn = true;
        manager.playerTurn = false;
    }
}
