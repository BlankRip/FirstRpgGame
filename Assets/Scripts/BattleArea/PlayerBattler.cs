using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattler : MonoBehaviour
{
    BattleManager manager;
    [SerializeField] Animator animate;
    [SerializeField] AudioManager manageSound;
    [SerializeField] float attackDamageNormal;
    float attackDamageCritical;
    [SerializeField] int specialDamageNormal;
    float specialDamageCritical;
    int hitChance;

    private void Start()
    {
        manager = FindObjectOfType<BattleManager>();
        attackDamageCritical = attackDamageNormal * 1.5f;
        specialDamageCritical = specialDamageNormal * 1.5f;
        print("settings");
        //var clip = animate.GetCurrentAnimatorClipInfo(0).Length;
    }

    public void Attack()
    {
        manageSound.AttackSound();
        animate.SetBool("Attacking", true);
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
        manager.enemyTurn = true;
        manager.playerTurn = false;
    }
    public void SpecialAttack()
    {
        manageSound.SpecialSound();
        animate.SetBool("Special", true);
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
        manager.enemyTurn = true;
        manager.playerTurn = false;
    }
    public void Defence()
    {
        manageSound.DefenceSound();
        animate.SetBool("Defending", true);
        manager.playerProtectionOn = true;
        manager.turnesProtected = 2;
        print("<color=green> NOW DEFENDING </color>");
        manager.enemyTurn = true;
        manager.playerTurn = false;
    }

    void Update()
    {
        
    }
}
