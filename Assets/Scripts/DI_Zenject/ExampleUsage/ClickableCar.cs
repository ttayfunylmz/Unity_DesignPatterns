using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

//This script detects clicks on a car using raycasting. When clicked, it increments a click count, 
//Updates the UI, plays a horn sound, and logs the click using injected dependencies.
public class ClickableCar : MonoBehaviour
{
    [SerializeField] private LayerMask _clickableLayer;

    private ClickableUI _clickableUI;
    private ClickableAudio _clickableAudio;
    private NonMonoExample _nonMonoExample;

    private int _clickCount;

    [Inject]
    private void ZenjectSetup(ClickableUI clickableUI, ClickableAudio clickableAudio, NonMonoExample nonMonoExample)
    {
        _clickableUI = clickableUI;
        _clickableAudio = clickableAudio;
        _nonMonoExample = nonMonoExample;
    }

    private void Update()
    {
        DetectCarWithRaycast();
    }

    private void DetectCarWithRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _clickableLayer))
            {
                if (hit.collider != null)
                {
                    _clickCount++;
                    _clickableUI.SetClickText(_clickCount);
                    _clickableAudio.PlayHornSound();
                    _nonMonoExample.JustClick();
                }
            }
        }
    }
}
