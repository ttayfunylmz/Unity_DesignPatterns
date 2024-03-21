using UnityEngine;

//Class representing a basketball object in the game.
public class Basketball : MonoBehaviour
{
    [SerializeField] private ScoreManager score;
    [SerializeField] private float forceValue = 1f;

    private Rigidbody basketballRigidbody;

    private void Awake() 
    {
        basketballRigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        basketballRigidbody.AddForce(Vector3.up * forceValue, ForceMode.Force);
        int currentScore = score.GetScore() + 1;

        //Publishing a UIEvent through the EventBus.
        EventBus<UIEvent>.Publish(new UIEvent
        {
            value = currentScore
        });

        // Publishing a SoundEvent through the EventBus.
        EventBus<SoundEvent>.Publish(new SoundEvent());
    }
}
