using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {
    private AudioSource MusicSource;
    private AudioSource ArrowSource;
    private AudioSource WindSource;
    private AudioSource WaterSource;

    public GameAudios Audios;

    private void Start()
    {
        MusicSource = AddAudioSource(0.5f);
        ArrowSource = AddAudioSource(1f);

        WaterSource = AddAudioSource(0.1f);
        WindSource = AddAudioSource(0.05f);

        PlayLoop(MusicSource, Audios.InGameMusic);
        PlayLoop(WindSource, Audios.Wind);
        PlayLoop(WaterSource, Audios.Water);
    }

    private AudioSource AddAudioSource(float Volume)
    {
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
        newAudioSource.playOnAwake = false;
        newAudioSource.loop = false;
        SetVolume(newAudioSource, Volume);
        
        return newAudioSource;
    }

    private void SetVolume(AudioSource Audio, float Volume)
    {
        Audio.volume = Volume;
    }

    private void PlayLoop(AudioSource Audio, AudioClip Clip)
    {
        Audio.loop = true;
        Audio.clip = Clip;
        Audio.Play();
    }

    private void PlayOneShot(AudioSource Audio, AudioClip Clip)
    {
        Audio.PlayOneShot(Clip);
    }

    public void PlayArrow()
    {
        PlayOneShot(ArrowSource, Audios.Arrow);
    }
}
 