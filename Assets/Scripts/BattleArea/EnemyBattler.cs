using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBattler : MonoBehaviour
{
    //Basics
    BattleManager manager;
    AudioManager manageSounds;
    ParticleManager manageParticles;
    [SerializeField] Animator attackAnimations;
    public int enemyHealth;                                   //The amount of health the enemy will have

    //Stuff related to attacking
    [SerializeField] float attackDamage;                      // Amount of damage enemy will do to player when using normal attack
    [SerializeField] float specialDamage;                     // Amount of damage enemy will do to player when using special attack
    float attackDamageCritical;                               // Amount of damage done when the normal attack is a critical hit
    float specialDamageCritical;                              // Amount of damage done when the special attack is a critical hit
    int critChance;                                           // A random number generated to decide if the attack should be a critical hit
    int whichAttack;                                          // A random number generated to decide on which attack to use
    int animationLength;                                        // Time taken for animation to complete

    // Choosing enemy type in inspector
    [SerializeField] bool firstForm;
    [SerializeField] bool secondForm;
    [SerializeField] bool finalForm;

    private void Start()
    {
        manager = FindObjectOfType<BattleManager>();
        manageSounds = FindObjectOfType<AudioManager>();
        manageParticles = FindObjectOfType<ParticleManager>();
        attackDamageCritical = attackDamage + (attackDamage * 0.25f);                  // Setting the value of the critical damage for normal attack
        specialDamageCritical = specialDamage + (specialDamage * 0.3f);                // Setting the value of the critical damage for special attack
    }

    // Update is called once per frame
    void Update()
    {
        //Check if it is enemy's turn and then let the enemy attack the player and switch it back to the player's turn
        if (manager.enemyTurn == true)
        {
            if (manager.playerProtectionOn == false)
            {
                whichAttack = Random.Range(0, 3);
                critChance = Random.Range(0, 10);

                //Perform normal attack
                if (whichAttack < 2)
                {
                    //Normal attack animation
                    attackAnimations.SetTrigger("Normal");
                    StartCoroutine(manageParticles.EnemyAttackParticles(2));
                    animationLength = attackAnimations.GetCurrentAnimatorClipInfo(0).Length;                      //Getting time it takes to finish the animation
                    StartCoroutine(GoToPlayerTurn(animationLength));                                             //Waiting for animation to complete then switch turns

                    //Normal attack sound effect
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
                else                                                                            //Perform special attack
                {
                    // Special attack animation
                    attackAnimations.SetTrigger("Special");
                    animationLength = attackAnimations.GetCurrentAnimatorClipInfo(0).Length;                      //Getting time it takes to finish the animation
                    StartCoroutine(GoToPlayerTurn(animationLength));                                             //Waiting for animation to complete then switch on player battle options

                    //Based on the enemy the sound effect to play for their special attack
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
            else                                                                                           // If player cast proection spell and is till under it's influance
            {
                attackAnimations.SetTrigger("Normal");                                                        // Just perfom attack and tell player he is protected
                animationLength = attackAnimations.GetCurrentAnimatorClipInfo(0).Length;                      //Getting time it takes to finish the animation
                StartCoroutine(GoToPlayerTurn(animationLength));                                              //Waiting for animation to complete then switch on player battle options

                // Protected sound effect
                manageSounds.ProtectedSound();
                print("Protected");
            }

            // Checkeing if the turn the influance of the protectioin spell will last and setting it's value
            if (manager.turnesProtected > 0)
                manager.turnesProtected--;
            if (manager.turnesProtected <= 0)
                manager.playerProtectionOn = false;

            //Switching turns
            manager.playerTurn = true;
            manager.enemyTurn = false;
        }
    }

    IEnumerator GoToPlayerTurn(int waitTime)
    {
        // Waiting for animation to finish
        yield return new WaitForSeconds(waitTime + 2);

        // Turn on the player Battle options
        manager.playerBattleUI.SetActive(true);
    }
}
