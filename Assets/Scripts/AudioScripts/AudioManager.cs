using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    [Range(0f, 1f)]
    public float masterVolume;

    public static AudioManager instance;

    [SerializeField]
    private string THEME_NAME = "Theme";

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound sound in sounds) {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.name = sound.name;

            sound.source.clip = sound.clip;
            sound.source.loop = sound.loop;
            sound.source.playOnAwake = sound.playOnAwake;

            sound.source.volume = sound.volume * masterVolume; 
        }
    }

    private void Start()
    {
        Sound[] soundsToPlay = Array.FindAll(sounds, sound => sound.playOnAwake);
        if(soundsToPlay != null) {
            Array.ForEach(soundsToPlay, sound => sound.source.Play());
        }
    }

    public void Play(string soundName)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == soundName);
        if(sound == null) {
            Debug.LogWarning("Sound " + soundName + " was not found");
            return;
        }
        sound.source.Play();
    }

    public void OnMasterVolumeChange(float valueChange)
    {
        masterVolume = valueChange;
        Array.ForEach(sounds, sound => sound.source.volume = sound.volume * masterVolume);
    }

    public void OnVolumeChange(float valueChange)
    {
        Sound sound = Array.Find(sounds, sound => sound.name == THEME_NAME);
        if (sound != null) {
            sound.source.volume = valueChange * masterVolume;
        }
    }

}
