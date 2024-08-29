using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
