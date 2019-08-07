using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("The sound source")]
    [SerializeField] AudioSource BattleAudioSource;
    [SerializeField] AudioSource worldAudioSource;

    [Header("The sound Effects")]
    [SerializeField] AudioClip attackClip;
    [SerializeField] AudioClip specialClip;
    [SerializeField] AudioClip defenceClip;
    [SerializeField] AudioClip protectedClip;
    [SerializeField] AudioClip needManaClip;
    [SerializeField] AudioClip victoryClip;
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip enemyAttackClip;
    [SerializeField] AudioClip form1SpecialClip;
    [SerializeField] AudioClip form2SpecialClip;
    [SerializeField] AudioClip finalFormSpecialClip;

    [Header("Stuff required to give fade effect")]
    [SerializeField] float fadeSpeed;
    [HideInInspector] public bool fadeToBattle = false;
    [HideInInspector] public bool fadeToWorld = false;

    private void Update()
    {
        //To start the fades when these bools are made true in other scripts
        if(fadeToBattle)
        {
            StartCoroutine(Fade(BattleAudioSource, worldAudioSource, 0.38f, 0.3f));
            fadeToBattle = false;
        }
        else if(fadeToWorld)
        {
            StartCoroutine(Fade(worldAudioSource, BattleAudioSource, 0.3f, 0.38f));
            fadeToWorld = false;
        }
    }


    //Functions to playone shot when called in any other script
    public void AttackSound()
    {
        BattleAudioSource.PlayOneShot(attackClip);
    }

    public void SpecialSound()
    {
        BattleAudioSource.PlayOneShot(specialClip);
    }

    public void DefenceSound()
    {
        BattleAudioSource.PlayOneShot(defenceClip);
    }

    public void ProtectedSound()
    {
        BattleAudioSource.PlayOneShot(protectedClip);
    }

    public void NeedManaSound()
    {
        BattleAudioSource.PlayOneShot(needManaClip);
    }

    public void VictorySound()
    {
        BattleAudioSource.PlayOneShot(victoryClip);
    }

    public void DeathSound()
    {
        BattleAudioSource.PlayOneShot(deathClip);
    }

    public void EnemyAttackSound()
    {
        BattleAudioSource.PlayOneShot(enemyAttackClip);
    }

    public void SpecialOneSound()
    {
        BattleAudioSource.PlayOneShot(form1SpecialClip);
    }

    public void SpecialSecondSound()
    {
        BattleAudioSource.PlayOneShot(form2SpecialClip);
    }

    public void SpecialFinalSound()
    {
        BattleAudioSource.PlayOneShot(finalFormSpecialClip);
    }


    // Core-rotine stuff to fad music in and out when entering battle and exiting battle
    public IEnumerator Fade(AudioSource source, AudioSource forOut, float maxVolume, float startOutVoulume)
    {
        forOut.volume = startOutVoulume;
        while (forOut.volume > 0)
        {
            startOutVoulume -= fadeSpeed;
            forOut.volume = startOutVoulume;
            yield return new WaitForSeconds(0.03f);
        }

        float currentVolume = 0;
        source.volume = currentVolume;
        while (source.volume < maxVolume)
        {
            currentVolume += fadeSpeed;
            source.volume = currentVolume;
            yield return new WaitForSeconds(0.03f);
        }
        yield return new WaitForSeconds(0.3f);
    }
}
