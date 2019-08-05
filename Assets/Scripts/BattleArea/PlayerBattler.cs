using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattler : MonoBehaviour
{
    //Basics
    BattleManager manager;
    AudioManager manageSound;
    ParticleManager manageParticles;
    [SerializeField] Animator animate;

    //Stuff related to attacking
    [SerializeField] float attackDamageNormal;                      // Amount of damage player will do to enemy when using normal attack
    [SerializeField] int specialDamageNormal;                       // Amount of damage player will do to enemy when using special attack
    float attackDamageCritical;                                     // Amount of damage done when the normal attack is a critical hit
    float specialDamageCritical;                                    // Amount of damage done when the special attack is a critical hit
    int hitChance;                                                  // A random number generated to decide if the attack should be a critical hit
    int animationClipLength;                                        // Time taken for animation to complete

    private void Start()
    {
        manager = FindObjectOfType<BattleManager>();
        manageSound = FindObjectOfType<AudioManager>();
        manageParticles = FindObjectOfType<ParticleManager>();
        attackDamageCritical = attackDamageNormal * 1.5f;                  // Setting the value of the critical damage for normal attack
        specialDamageCritical = specialDamageNormal * 1.5f;                // Setting the value of the critical damage for special attack
    }


    //Attack Function
    public void Attack()
    {
        manageSound.AttackSound();                                                               //Play attack soundeffect
        animate.SetTrigger("Attacking");                                                         //Attack animation
        manager.playerBattleUI.SetActive(false);                                                 //Turning off player battle options
        StartCoroutine(manageParticles.PlayerAttackParticle(2));                                 // Particle effects
        animationClipLength = animate.GetCurrentAnimatorClipInfo(0).Length;                      //Getting time it takes to finish the animation
        StartCoroutine(SwitchTruns(animationClipLength));                                        //Waiting for animation to complete then switch turns

        hitChance = Random.Range(0, 10);
        if (hitChance < 7)
        {
            manager.currentBattler.enemyHealth -= (int)attackDamageNormal;
            manager.enemyHealthBar.value = manager.currentBattler.enemyHealth;
            manager.DidEnemyDie();
        }
        else if(hitChance >= 7)
        {
            manager.currentBattler.enemyHealth -= (int)attackDamageCritical;
            manager.enemyHealthBar.value = manager.currentBattler.enemyHealth;
            manager.DidEnemyDie();
        }
    }


    //Special Attack function
    public void SpecialAttack()
    {
        manageSound.SpecialSound();                                                              //Play special soundeffect
        animate.SetTrigger("Special");                                                           //Special animation
        manager.playerBattleUI.SetActive(false);                                                 //Turning off player battle options
        StartCoroutine(manageParticles.PlayerSpecialParticle(1.3f));                                // Particle effects
        animationClipLength = animate.GetCurrentAnimatorClipInfo(0).Length;                      //Getting time it takes to finish the animation
        StartCoroutine(SwitchTruns(animationClipLength));                                        //Waiting for animation to complete then switch turns

        hitChance = Random.Range(0, 10);
        if (hitChance <= 8 && hitChance >= 2)
        {
            manager.currentBattler.enemyHealth -= (int)specialDamageNormal;
            manager.enemyHealthBar.value = manager.currentBattler.enemyHealth;
            manager.DidEnemyDie();
        }
        else if (hitChance < 2 || hitChance == 9)
        {
            manager.currentBattler.enemyHealth -= (int)specialDamageCritical;
            manager.enemyHealthBar.value = manager.currentBattler.enemyHealth;
            manager.DidEnemyDie();
        }
    }


    //Defence spell function
    public void Defence()
    {
        manageSound.DefenceSound();                                                              //Play defence spell soundeffect
        animate.SetTrigger("Defending");                                                         //Defence animation
        manager.playerBattleUI.SetActive(false);                                                 //Turning off player battle options
        animationClipLength = animate.GetCurrentAnimatorClipInfo(0).Length;                      //Getting time it takes to finish the animation
        StartCoroutine(SwitchTruns(animationClipLength));                                        //Waiting for animation to complete then switch turns

        manager.playerProtectionOn = true;
        manager.turnesProtected = 2;
    }


    //Function to wait for animation to finish then switch turns
    IEnumerator SwitchTruns(int waitTime)
    {
        // Waiting for animation to finish
        yield return new WaitForSeconds(waitTime + 2);

        //Switching turns
        manager.enemyTurn = true;
        manager.playerTurn = false;
    }
}
