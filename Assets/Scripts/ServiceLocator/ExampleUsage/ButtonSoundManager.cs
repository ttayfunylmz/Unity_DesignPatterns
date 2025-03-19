using UnityEngine;

/// <summary>
/// Manages button click sounds.
/// Responsible for playing a sound effect when a button is clicked.
/// </summary>
public class ButtonSoundManager : MonoBehaviour
{
    private AudioSource _audioSource;

    /// <summary>
    /// Initializes the AudioSource component.
    /// </summary>
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    /// <summary>
    /// Plays the button click sound.
    /// </summary>
    public void PlayButtonSound() => _audioSource.Play();
}
