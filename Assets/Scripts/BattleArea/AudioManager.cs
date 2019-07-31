using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("The sound source")]
    [SerializeField] AudioSource audioSource;

    [Header("The sound Effects")]
    [SerializeField] AudioClip attackClip;
    [SerializeField] AudioClip specialClip;
    [SerializeField] AudioClip defenceClip;
    [SerializeField] AudioClip protectedClip;
    [SerializeField] AudioClip victoryClip;
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip enemyAttackClip;
    [SerializeField] AudioClip form1SpecialClip;
    [SerializeField] AudioClip form2SpecialClip;
    [SerializeField] AudioClip finalFormSpecialClip;
    


    //Functions to playone shot when called in any other script
    public void AttackSound()
    {
        audioSource.PlayOneShot(attackClip);
    }

    public void SpecialSound()
    {
        audioSource.PlayOneShot(specialClip);
    }

    public void DefenceSound()
    {
        audioSource.PlayOneShot(defenceClip);
    }

    public void ProtectedSound()
    {
        audioSource.PlayOneShot(protectedClip);
    }

    public void VictorySound()
    {
        audioSource.PlayOneShot(victoryClip);
    }

    public void DeathSound()
    {
        audioSource.PlayOneShot(deathClip);
    }

    public void EnemyAttackSound()
    {
        audioSource.PlayOneShot(enemyAttackClip);
        print("<color=pink> entered</color>");
    }

    public void SpecialOneSound()
    {
        audioSource.PlayOneShot(form1SpecialClip);
        print("<color=red> entered</color>");
    }

    public void SpecialSecondSound()
    {
        audioSource.PlayOneShot(form2SpecialClip);
        print("<color=red> entered</color>");
    }

    public void SpecialFinalSound()
    {
        audioSource.PlayOneShot(finalFormSpecialClip);
        print("<color=red> entered</color>");
    }
}
