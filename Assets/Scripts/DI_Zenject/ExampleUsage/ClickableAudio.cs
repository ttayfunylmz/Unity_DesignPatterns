using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script handles the playing of a horn sound when triggered,
//Using an AudioSource component attached to the same GameObject.
public class ClickableAudio : MonoBehaviour
{
    [SerializeField] private AudioClip _hornSound;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayHornSound()
    {
        _audioSource.PlayOneShot(_hornSound);
    }
}
