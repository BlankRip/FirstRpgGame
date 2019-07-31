using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;
    bool paused = false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!paused)                                   //Switching on the pause screen and making the game in the background freeze
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                paused = true;
            }
            else if(paused)                               //Switching back into the game, resumeing
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }

        }
    }
}
