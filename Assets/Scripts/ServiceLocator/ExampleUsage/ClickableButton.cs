using DG.Tweening;
using UnityEngine;

/// <summary>
/// Handles button clicks using raycasting and triggers animations and sound effects.
/// Also updates the click counter UI.
/// </summary>
public class ClickableButton : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform _buttonTransform; // Reference to the button's transform
    [SerializeField] private LayerMask _clickableLayer; // Layer mask to detect clickable objects

    [Header("Settings")]
    [SerializeField] private float _animationDuration = 0.2f; // Duration of the button animation

    private bool _isAnimating; // Flag to prevent multiple animations at once
    private int _clickAmount; // Tracks the number of clicks

    /// <summary>
    /// Checks for button clicks using raycasting every frame.
    /// </summary>
    private void Update()
    {
        DetectButtonWithRaycast();
    }

    /// <summary>
    /// Detects button clicks using a raycast from the mouse position.
    /// If a button is clicked, it plays an animation, sound, and updates the click counter.
    /// </summary>
    private void DetectButtonWithRaycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _clickableLayer))
            {
                if (hit.collider != null)
                {
                    AnimateButtonClick();

                    // Try to play button sound if the sound manager is registered
                    if (ServiceLocator.TryGetService<ButtonSoundManager>(out var soundManager))
                    {
                        soundManager.PlayButtonSound();
                    }

                    _clickAmount++;

                    // Try to update the click counter UI if it is registered
                    if (ServiceLocator.TryGetService<ClickCounterUI>(out var clickCounterUI))
                    {
                        clickCounterUI.SetClickText(_clickAmount);
                    }
                }
            }
        }
    }

    /// <summary>
    /// Animates the button click by moving it slightly and then returning it to its original position.
    /// Prevents multiple animations from triggering at once.
    /// </summary>
    private void AnimateButtonClick()
    {
        if (_isAnimating) { return; }

        _isAnimating = true;

        _buttonTransform.DOLocalMove(Vector3.zero, _animationDuration)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                _buttonTransform.DOLocalMove(new Vector3(0f, 0f, 0.25f), _animationDuration)
                    .SetEase(Ease.Linear)
                    .OnComplete(() =>
                    {
                        _isAnimating = false;
                    });
            });
    }
}
