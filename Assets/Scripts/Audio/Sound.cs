using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    [HideInInspector]
    public AudioSource Source;
    public AudioClip AudioClip;
    public string Name;
    [Range(0f, 1f)] public float Volume;
    [Range(.1f, 3f)] public float Pitch;
    public bool Mute;
    public bool Loop;
    public bool playOnAwake;
}