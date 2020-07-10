
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Button musicbutton;
    public Sprite mute;
    public Sprite unmute;

    public static int Counter;

    void Start()
    {
        Counter = PlayerPrefs.GetInt("Mute", 0);

        //if (Counter == 0)
        //{
        //    musicbutton.GetComponent<Image>().sprite = mute;
        //}
        //else
        //{
        //    musicbutton.GetComponent<Image>().sprite = unmute;
        //}
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("MusicVol", Mathf.Log10(volume) *20 );
    }



    public void Settingss()
    {
        

        if (Counter == 0)
        {
            DontDestroyOnLoad(gameObject);
            PlayerPrefs.SetInt("Mute", 1);
            musicbutton.GetComponent<Image>().sprite = mute;

            Counter = 1;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            PlayerPrefs.SetInt("Mute", 0);
            musicbutton.GetComponent<Image>().sprite = unmute;
            Counter = 0;

        }

    }

    /*public void resume()
    {
        settingsMenuUI.SetActive(false);

    }*/
}
