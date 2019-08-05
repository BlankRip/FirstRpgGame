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

    [Header("Stuff required to give fade effect")]
    [SerializeField] float fadeSpeed;
    


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
    }

    public void SpecialOneSound()
    {
        audioSource.PlayOneShot(form1SpecialClip);
    }

    public void SpecialSecondSound()
    {
        audioSource.PlayOneShot(form2SpecialClip);
    }

    public void SpecialFinalSound()
    {
        audioSource.PlayOneShot(finalFormSpecialClip);
    }

    public IEnumerator FadeIn(AudioSource source, AudioSource forOut, float maxVolume, float startOutVoulume)
    {
        forOut.volume = startOutVoulume;
        while (forOut.volume > 0)
        {
            startOutVoulume -= fadeSpeed;
            forOut.volume = startOutVoulume;
            print("out here");
        }

        float currentVolume = 0;
        source.volume = currentVolume;
        while (source.volume < maxVolume)
        {
            currentVolume += fadeSpeed;
            source.volume = currentVolume;
            print("in here");
        }
        yield return new WaitForSeconds(0.3f);
    }
}
