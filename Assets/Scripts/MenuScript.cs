using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject ControlScreen;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip letsGoClip;

    public void ShowControls()
    {
        MainMenu.SetActive(false);
        ControlScreen.SetActive(true);
        audioSource.PlayOneShot(letsGoClip);
    }

    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
