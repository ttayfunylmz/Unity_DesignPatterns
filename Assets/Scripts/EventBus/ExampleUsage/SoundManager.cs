using UnityEngine;

//Class for managing game sounds.
public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip basketballBounceAudioClip;

    private AudioSource audioSource;

    private EventBinding<SoundEvent> soundEventBinding;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();    
    }

    private void OnEnable()
    {
        //Creating a new EventBinding for SoundEvents and subscribing it to the SoundEvent EventBus.
        soundEventBinding = new EventBinding<SoundEvent>(HandleSoundEvent);
        EventBus<SoundEvent>.Subscribe(soundEventBinding);
    }

    private void HandleSoundEvent(SoundEvent soundEvent)
    {
        audioSource.PlayOneShot(basketballBounceAudioClip);
        Debug.Log("Sound Event Raised!");
    }

    private void OnDisable()
    {
        //Unsubscribing the SoundEvent EventBinding from the EventBus.
        EventBus<SoundEvent>.Unsubscribe(soundEventBinding); 
    }
}
