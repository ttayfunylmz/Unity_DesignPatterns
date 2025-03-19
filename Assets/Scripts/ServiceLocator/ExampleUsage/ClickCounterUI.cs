using TMPro;
using UnityEngine;

/// <summary>
/// Manages the UI display for the click counter.
/// Updates the on-screen text to show the number of clicks.
/// </summary>
public class ClickCounterUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _clickText; // Reference to the UI text element

    /// <summary>
    /// Initializes the click counter display.
    /// </summary>
    private void Start()
    {
        SetClickText(0);
    }

    /// <summary>
    /// Updates the click counter UI text with the given amount.
    /// </summary>
    /// <param name="amount">The current number of clicks.</param>
    public void SetClickText(int amount)
    {
        _clickText.text = "CLICK: " + amount.ToString();
    }
}
