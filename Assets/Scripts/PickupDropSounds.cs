using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDropSounds : MonoBehaviour
{
    private AudioSource _audioSource;
    public AudioClip pickup, drop;
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    void Pickup()
    {
        _audioSource.clip = pickup;
        _audioSource.Play();
    }

    void Drop()
    {
        _audioSource.clip = drop;
        _audioSource.Play();
    }
}
