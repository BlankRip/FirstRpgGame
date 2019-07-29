using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattler : MonoBehaviour
{
    BattleManager manager;
    AudioManager manageSounds;
    public int enemyHealth;
    [SerializeField] Animator attackAnimations;
    [SerializeField] float attackDamage;
    [SerializeField] float specialDamage;
    float attackDamageCritical;
    float specialDamageCritical;
    int critChance;
    int whichAttack;
    [SerializeField] bool firstForm;
    [SerializeField] bool secondForm;
    [SerializeField] bool finalForm;

    private void Start()
    {
        manager = FindObjectOfType<BattleManager>();
        manageSounds = FindObjectOfType<AudioManager>();
        attackDamageCritical = attackDamage + (attackDamage * 0.25f);
        specialDamageCritical = specialDamage + (specialDamage * 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.enemyTurn == true)
        {
            if (manager.playerProtectionOn == false)
            {
                whichAttack = Random.Range(0, 3);
                critChance = Random.Range(0, 10);
                if (whichAttack < 2)
                {
                    attackAnimations.SetTrigger("Normal");
                    manageSounds.EnemyAttackSound();
                    if (critChance > 7)
                    {
                        manager.playerHealth -= (int)attackDamageCritical;
                        manager.playerHealthBar.value = manager.playerHealth;
                        manager.DidPlayerDie();
                        print("<color=blue> my trun crit</color>");
                    }
                    else
                    {
                        manager.playerHealth -= (int)attackDamage;
                        manager.playerHealthBar.value = manager.playerHealth;
                        manager.DidPlayerDie();
                        print("<color=blue> my trun</color>");
                    }
                }
                else
                {
                    attackAnimations.SetTrigger("Special");

                    if (firstForm)
                        manageSounds.SpecialOneSound();
                    else if (secondForm)
                        manageSounds.SpecialSecondSound();
                    else if (finalForm)
                        manageSounds.SpecialFinalSound();

                    if (critChance > 7)
                    {
                        manager.playerHealth -= (int)specialDamageCritical;
                        manager.playerHealthBar.value = manager.playerHealth;
                        manager.DidPlayerDie();
                        print("<color=blue> my trun crit spe</color>");
                    }
                    else
                    {
                        manager.playerHealth -= (int)specialDamage;
                        manager.playerHealthBar.value = manager.playerHealth;
                        manager.DidPlayerDie();
                        print("<color=blue> my trun spe</color>");
                    }
                }
            }
            else
            {
                manageSounds.ProtectedSound();
                print("Protected");
                attackAnimations.SetTrigger("Normal");
            }

            if (manager.turnesProtected > 0)
                manager.turnesProtected--;
            if (manager.turnesProtected <= 0)
                manager.playerProtectionOn = false;
            manager.playerTurn = true;
            manager.enemyTurn = false;
        }
    }
}
