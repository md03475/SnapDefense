using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool Gamepaused = false;

    public GameObject pauseMenuUI;


    public void Pause()
    {

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Gamepaused = true;


    }

    public void resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Gamepaused = false;
    }

    public void restart()
    {
       
        Time.timeScale = 1f;

    }

}
