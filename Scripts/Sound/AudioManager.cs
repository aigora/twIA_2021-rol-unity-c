using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioSource Music;
    // Start is called before the first frame update
    void Awake()
    {

    }
     
    void Start ()
    {

    }
    // Update is called once per frame
    public void ChangeMusic (AudioClip music)
    {
        if (Music.clip.name == music.name)
            return;
        Music.Stop();
        Music.clip = music;
        Music.Play();
    }
}
