using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;
public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Sound[] sounds;

    private AudioSource audioSrc;
    //public Button changemute;
  
    private float musicVolume = 1f;

    public static int Soundeffects;
    public GameObject settingsMenuUI;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

        }
    }

    // Use this for initialization
    void Start()
    {
        Soundeffects = PlayerPrefs.GetInt("Ind", 0);
        audioSrc = GetComponent<AudioSource>();

    }

    void Update()
    {

        audioSrc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

    // Update is called once per frame
    public void Play(string name)
    {
        if (Soundeffects == 0)
        {
            Sound s = Array.Find(sounds, sound => sound.name == name);
            s.source.Play();
        }
    }
    public void StopplayingAllSounds()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    public void Stopplaying()
    {
       
        if (Soundeffects == 0)
        {
            PlayerPrefs.SetInt("Ind", 1);
            
            Soundeffects = 1;
        }
        else
        {
            PlayerPrefs.SetInt("Ind", 0);
            
            Soundeffects = 0;

        }    
    }
}
