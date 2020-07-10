using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound
{
    // Start is called before the first frame update
    public string name;

    public AudioClip clip;

    [Range(0f, 3f)]
    public float volume;

    [Range(0.1f, 3f)]
    public float pitch;

    [HideInInspector]
    public AudioSource source;
}
