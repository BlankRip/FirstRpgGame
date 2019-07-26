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
    [SerializeField] AudioClip victoryClip;
    [SerializeField] AudioClip deathClip;
    
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

    public void VictorySound()
    {
        audioSource.PlayOneShot(victoryClip);
    }

    public void DeathSound()
    {
        audioSource.PlayOneShot(deathClip);
    }
}
