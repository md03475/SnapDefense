using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    

    public int a;

    public void SceneLoader(int ind)
    {
        SceneManager.LoadScene(ind);
    }
    
    public void Shop()
    {
        a = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(6);

    }

    public void quitfromgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void BackfromShop()
    {
        SceneManager.LoadScene(a);
    }

    public void Quitgame()
    {
        Debug.Log("Quit Game working");
        Application.Quit();
    }
}
