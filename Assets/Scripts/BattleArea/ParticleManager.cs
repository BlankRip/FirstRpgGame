using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [Header("The particle system for each effect")]
    [SerializeField] ParticleSystem playerAttack;
    [SerializeField] ParticleSystem playerSpecial;
    [SerializeField] ParticleSystem enemyAttack;


    //Functions which start the particle effect in parallel when called and then stop it after the set amount of time
    public IEnumerator PlayerAttackParticle(int waitTime)
    {
        playerAttack.Play();

        yield return new WaitForSeconds(waitTime);

        playerAttack.Stop();
    }


    public IEnumerator PlayerSpecialParticle(float waitTime)
    {
        playerSpecial.Play();

        yield return new WaitForSeconds(waitTime);

        playerSpecial.Stop();
    }


    public IEnumerator EnemyAttackParticles(int waitTime)
    {
        enemyAttack.Play();

        yield return new WaitForSeconds(waitTime);

        enemyAttack.Stop();
    }
}
