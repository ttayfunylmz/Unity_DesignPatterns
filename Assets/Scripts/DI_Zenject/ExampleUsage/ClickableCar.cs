using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableCar : MonoBehaviour
{
    [SerializeField] private LayerMask _clickableLayer;
    [SerializeField] private ClickableUI _clickableUI;
    [SerializeField] private ClickableAudio _clickableAudio;

    private int _clickCount;

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
                }
            }
        }
    }
}
