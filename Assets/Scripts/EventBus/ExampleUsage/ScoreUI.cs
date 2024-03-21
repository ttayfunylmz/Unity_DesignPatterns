using TMPro;
using UnityEngine;

//Class for managing the UI representation of the score.
public class ScoreUI : MonoBehaviour
{
    [SerializeField] private ScoreManager score;
    [SerializeField] private TMP_Text scoreText;

    //EventBinding for handling UI events.
    private EventBinding<UIEvent> uIEventBinding;

    private void OnEnable()
    {
        //Creating a new EventBinding for UI events and subscribing it to the UIEvent EventBus.
        uIEventBinding = new EventBinding<UIEvent>(HandleUIEvent);
        EventBus<UIEvent>.Subscribe(uIEventBinding);
    }

    private void HandleUIEvent(UIEvent uIEvent)
    {
        score.UpdateScore(1);
        scoreText.text = "Score: " + uIEvent.value;
        Debug.Log("UI event received with value: " + uIEvent.value);
    }

    private void OnDisable()
    {
        //Unsubscribing the UIEvent EventBinding from the EventBus.
        EventBus<UIEvent>.Unsubscribe(uIEventBinding); 
    }
}
