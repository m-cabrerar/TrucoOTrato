using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance {get; private set;}

    [SerializeField] private List<AudioSource> _audioSources = new List<AudioSource>();
    [SerializeField] private bool _isMute = false;
    [SerializeField] private float _volume = 1;
    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Play(SoundData soundData)
    {
        if (soundData == null)
        {
            return;
        }

        _audioSource = GetAvailableAudioSource();
        if (_audioSource == null)
        {
            return;
        }

        _audioSource.pitch = soundData.GetPitch();
        print(soundData.Volume);
        _audioSource.PlayOneShot(soundData.Clip, soundData.Volume);
    }

    private AudioSource GetAvailableAudioSource()
    {
        foreach(AudioSource source in _audioSources)
        {
            if(!source.isPlaying)
            {
                return source;
            }
        }

        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        _audioSources.Add(newSource);
        return newSource;
    }

    public void Mute(bool newIsMute)
    {
        _isMute = newIsMute;
        foreach(AudioSource source in _audioSources)
        {
            source.mute = newIsMute;
        }
    }

    public void SetVolume(float newVolume)
    {
        if (_volume == 0)
        {
            return;
        }
        float volumeDeltaRatio = newVolume/_volume;
        foreach(AudioSource source in _audioSources)
        {
            source.volume *= volumeDeltaRatio;
        }
        _volume = Mathf.Clamp01(newVolume);
    }
}