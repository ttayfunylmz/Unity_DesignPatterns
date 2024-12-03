using UnityEngine;
using Zenject;

//This script examines the use of a non-MonoBehaviour class as a dependency.
public class NonMonoExample
{
    [Inject] private ClickableAudio _clickableAudio;

    public NonMonoExample(ClickableAudio clickableAudio)
    {
        _clickableAudio = clickableAudio;
    }

    public void JustClick()
    {
        Debug.Log("Clicked!");
    }
}
