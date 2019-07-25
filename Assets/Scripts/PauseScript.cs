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
            if(!paused)
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                paused = true;
            }
            else if(paused)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
                paused = false;
            }

        }
    }
}
