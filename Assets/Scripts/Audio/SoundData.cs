using UnityEngine;
using System;

[Serializable]
public class SoundData
{
    public AudioClip Clip => _clip;
    public float Volume => _volume;

    [SerializeField] private AudioClip _clip;
    [SerializeField] private float _volume = 1;
    [SerializeField] private bool _isPitchRandom = false;
    [SerializeField] private float _minPitch = 0.5f;
    [SerializeField] private float _maxPitch = 1.5f;

    private const float DEFAULT_PITCH = 1f;

    public float GetPitch()
    {
        if (_isPitchRandom == false)
        {
            return DEFAULT_PITCH;
        }
        return UnityEngine.Random.Range(_minPitch, _maxPitch);
    }
}