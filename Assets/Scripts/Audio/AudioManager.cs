using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Sounds")]
    public Sound[] Sounds;

    private void Awake() 
    {
        Instance = this;

        foreach (Sound s in Sounds)
        {
          s.Source = gameObject.AddComponent<AudioSource>();
          s.Source.clip = s.AudioClip;
          s.Source.volume = s.Volume;
          s.Source.pitch = s.Pitch;
          s.Source.mute = s.Mute;
          s.Source.loop = s.Loop; 
          s.Source.playOnAwake = s.playOnAwake;
        }
    }

    public void Play(String Name)
    {
      Sound s = Array.Find(Sounds, Sound => Sound.Name == Name);
      if(s == null) return;    
        s.Source.Play();            
    }

    public void Stop(String Name)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == Name);
        if (s == null) return;     
            s.Source.Stop();                   
    }

    public void SoundEffectsActive(string Name)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == Name);
        if (s == null) return;
        s.Source.mute = false;
    }
   
    public void SoundEffectsPassive(string Name)
    {
       Sound s = Array.Find(Sounds, Sound => Sound.Name == Name);
       if(s == null) return;
        s.Source.mute = true;       
    }
}