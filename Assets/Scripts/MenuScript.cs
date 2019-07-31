using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject MainMenu;
    [SerializeField] GameObject ControlScreen;

    [SerializeField] AudioSource audioSource;        // Source
    [SerializeField] AudioClip letsGoClip;           // background music clip

    
    //Function to switch to control screen from the title screen
    public void ShowControls()
    {
        MainMenu.SetActive(false);
        ControlScreen.SetActive(true);
        audioSource.PlayOneShot(letsGoClip);
    }

    //Function to move to next scene
    public void startGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
